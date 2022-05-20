using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.BusinessObjects;
using Business.Services;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;

namespace Solution
{
    public class Mediator : IDisposable
    {
        private bool _disposed = false;

        private readonly Queue<Action> _queueActionsTimeTrack = new();

        public Mediator(UserServices userServices)
        {
            _userServices = userServices;
        }

        private UserServices _userServices;

        public event Action<string> NotifyMediator;

        public void SubscribeToNotify(Action<string> action) => NotifyMediator += action;

        public UserData GetUserData(int userId)
        {
            var userData = _userServices.GetUserById(userId);
            return userData;
        }

        public IEnumerable<UserData> GetUsersData(bool active)
        {
            return active ? Pointer(_userServices.GetAllUsers) : Pointer(_userServices.GetAllActiveUsers);
        }

        public void InsertProject(Project obj, IRepository<Project> repository)
        {
            repository.Insert(obj);
            NotifyMediator?.Invoke($"Проект {obj.Name} успешно добавлен");
        }

        public void InsertUser(User obj, IRepository<User> repository)
        {
            repository.Insert(obj);
            NotifyMediator?.Invoke($"Пользователь {obj.FullName} успешно добавлен");
        }

        public void InsertTimeTrack(TimeTrackEntry obj, IRepository<TimeTrackEntry> repository)
        {
            _queueActionsTimeTrack.Enqueue(() => repository.Insert(obj));
        }

        public void ApproveTimeTrack(bool claim)
        {
            if (claim)
            {
                ClearQueueTimeTrack();
                NotifyMediator.Invoke($"Отправка одобрена");
            }
            else
            {
                _queueActionsTimeTrack.Clear();
                NotifyMediator.Invoke($"Отправка запросов отклонена");
            }

        }
        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private static IEnumerable<UserData> Pointer(Func<IEnumerable<UserData>> func) => func();

        private void ClearQueueTimeTrack()
        {
            while (_queueActionsTimeTrack.Count != 0)
            {
                var action = _queueActionsTimeTrack.Dequeue();
                action.Invoke();
            }
        }

        private void CleanUp(bool clean)
        {
            if (_disposed)
            {
                if (clean)
                {
                    NotifyMediator?.Invoke($"Очищено");
                    GC.Collect();
                }
            }
            _disposed = true;
        }
    }
}
