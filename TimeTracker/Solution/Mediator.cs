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

        public Dictionary<Guid,Action<UserData>> _subscriptions = new();
        
        public Guid SubscribeToSubmittedTimeChanged(Action<UserData> action)
        {
            var subscriptionId = Guid.NewGuid();
            _subscriptions.Add(subscriptionId, action);
            return subscriptionId;
        }

        public void UnsubscribeFromSubmittedTimeChanged(Guid subscriptionId)
        {
            _subscriptions.Remove(subscriptionId);
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
