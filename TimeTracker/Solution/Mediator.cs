﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private readonly Queue<Action> _queueActionsData = new();

        private DataRepository _dataRepository = new();

        public UserServices userServices = new();

        private bool _disposed = false;

        public event Action<string> NotifyMediator;

        public void SubscribeToNotify(Action<string> action) => NotifyMediator += action;

        public void GetData()
        {
            _queueActionsData.Enqueue(GetUser);
            _queueActionsData.Enqueue(GetProject);
            _queueActionsData.Enqueue(GetTimeTrackEntry);
            if (_queueActionsData.Count == 3)
                ClearQueueActionsData();
            NotifyMediator?.Invoke("Все данные были успешно загружены");
            Dispose();

        }

        public UserData GetInUserData(DataRepository rep, int userId)
        {
            var userData = userServices.GetUserData(rep, userId);
            return userData;
        }

        public IEnumerable<UserData> GetUsersData(bool active)
        {
            return active ? Pointer(_dataRepository, userServices.GetAllUsers) : Pointer(_dataRepository, userServices.GetAllActiveUsers);
        }

        public void InsertProject(Project obj)
        {
            var pr = new RepositoriesXml<Project>();
            pr.Insert(obj);
            NotifyMediator?.Invoke($"Проект {obj.Name} успешно добавлен");
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private static IEnumerable<UserData> Pointer(DataRepository str, Func<DataRepository, IEnumerable<UserData>> func) => func(str);

        private void ClearQueueActionsData()
        {
            while (_queueActionsData.Count != 0)
            {
                var action = _queueActionsData.Dequeue();
                action.Invoke();
            }
        }

        private void CleanUp(bool clean)
        {
            if (_disposed)
            {
                if (clean)
                {
                    Console.WriteLine("Осовобожен");
                    GC.Collect();
                }
            }
            _disposed = true;
        }
        private void GetUser()
        {
            var ur = new RepositoriesXml<User>();
            _dataRepository.Users = ur.GetAll().ToList();
            NotifyMediator?.Invoke("Данные по Users успешно загружены");
        }

        private void GetProject()
        {
            var pr = new RepositoriesXml<Project>();
            _dataRepository.Projects = pr.GetAll().ToList();
            NotifyMediator?.Invoke("Данные по Projects успешно загружены");
        }

        private void GetTimeTrackEntry()
        {
            var tr = new RepositoriesXml<TimeTrackEntry>();
            _dataRepository.TimeTrackEntries = tr.GetAll().ToList();
            NotifyMediator?.Invoke("Данные по TimeTrackEntries успешно загружены");
        }
    }
}
