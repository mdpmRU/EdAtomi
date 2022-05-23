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

        private ArrayList _delegates = new ArrayList();
        private UserData userData;

        public UserServices userServices;
        

        public Mediator(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void SubscribeToSubmittedTimeChanged(Action<int> action, UserData userData)
        {
            userData.SubmittedTimeChanged += action;
            _delegates.Add(action);
        }

        public void UnsubscribeToSubmittedTimeChanged(Action<int> action, UserData userData) => userData.SubmittedTimeChanged -= action;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    RemoveAllListeners();
                    GC.Collect();
                }
            }
            _disposed = true;
        }

        private void RemoveAllListeners()
        {
            foreach (Action<int> d in _delegates) 
            {
                UnsubscribeToSubmittedTimeChanged(d,);
            }
        }
    }
}
