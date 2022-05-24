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

        public Dictionary<Guid,Action<int>> _subscriptions = new();
        
        public void RaiseSubmittedTimeChanged(UserData userData, Guid guid)
        {
            userData.SubmittedTimeChanged += _subscriptions[guid];
        }

        public Guid SubscribeToSubmittedTimeChanged(Action<int> action)
        {
            var guid = Guid.NewGuid();
            _subscriptions.Add(guid, action);
            return guid;
        }

        public void UnsubscribeFromSubmittedTimeChanged(Guid guid)
        {
            _subscriptions.Remove(guid);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _subscriptions.Clear();
                    GC.Collect();
                }
            }
            _disposed = true;
        }
    }
}
