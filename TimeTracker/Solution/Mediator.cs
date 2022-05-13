using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly Queue<Action> _queueActionsData = new();

        public static UserServices userServices = new UserServices();
        public Stubs Stub = userServices.Stubs;

        public delegate void MediatorDelegateEventHandler(string notification);
        public event MediatorDelegateEventHandler NotifyMediator;

        public void SubscribeToSomething(Action action) => action();

        public void GetUser()
        {
            var ur = new RepXML<User>();
            _queueActionsData.Enqueue(() => Stub.Users = ur.GetAll().ToList());
            NotifyMediator?.Invoke("Данные по Users успешно загружены");
        }
        public void GetProject()
        {
            var pr = new RepXML<Project>();
            _queueActionsData.Enqueue(() => Stub.Projects = pr.GetAll().ToList());
            NotifyMediator?.Invoke("Данные по Projects успешно загружены");
        }
        public void GetTimeTrackEntry()
        {
            var tr = new RepXML<TimeTrackEntry>();
            _queueActionsData.Enqueue(() => Stub.TimeTrackEntries = tr.GetAll().ToList());
            NotifyMediator?.Invoke("Данные по TimeTrackEntries успешно загружены");
        }

        public IEnumerable<UserData> GetUserData(bool active)
        {
            
            if (active)
            {
                return Pointer(userServices.GetAllUsers);
            }
            else
            {
                return Pointer(userServices.GetAllActiveUsers);
            }
        }

        public void InsertProject(Project obj)
        {
            RepXML<Project> pr = new RepXML<Project>();
            pr.Insert(obj);
            NotifyMediator?.Invoke($"Проект {obj.Name} успешно добавлен");
        }
        public void Dispose()
        {
            ClearQueueActionsData();
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        private IEnumerable<UserData> Pointer(Func<IEnumerable<UserData>> func) => func();

        private void ClearQueueActionsData()
        {
            while (_queueActionsData.Count != 0)
            {
                var action = _queueActionsData.Dequeue();
                action.Invoke();
            }
        }
    }
}
