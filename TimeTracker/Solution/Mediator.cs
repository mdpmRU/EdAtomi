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

        private UserServices _userServices;

        public Mediator(UserServices userServices)
        {
            _userServices = userServices;
        }

        public void SubscribeToNotify(Action<string> action) => NotifyMediator += action;

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
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
