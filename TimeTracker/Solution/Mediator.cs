using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessObjects;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;

namespace Solution
{
    public class Mediator : IDisposable
    {
        public Stubs stubs = new Stubs();
        public delegate void MediatorDelegateEventHandler();
        public event MediatorDelegateEventHandler mediator;//Добавить уведомление об успешной загрузки
        //private Queue<MediatorDelegateEventHandler> queue = new Queue<MediatorDelegateEventHandler>();

        public Queue<Action> QueueActionsData = new Queue<Action>();

        public void SubscribeToSomething(Action action) => action();

        public void GetUser()
        {
            RepXML<User> ur = new RepXML<User>();
            QueueActionsData.Enqueue(()=>stubs.Users = ur.GetAll().ToList());
            mediator?.Invoke();
        }
        public void GetProject()
        {
            RepXML<Project> pr = new RepXML<Project>();
            QueueActionsData.Enqueue(() => stubs.Projects = pr.GetAll().ToList());
            mediator?.Invoke();
        }
        public void GetTimeTrackEntry()
        {
            RepXML<TimeTrackEntry> tr = new RepXML<TimeTrackEntry>();
            QueueActionsData.Enqueue(() => stubs.TimeTrackEntries = tr.GetAll().ToList());
            mediator?.Invoke();
        }

        public void Dispose()//разобраться
        {
            ClearQueueActionsData();
            GC.SuppressFinalize(this);
        }

        private void ClearQueueActionsData()
        {
            Action action;
            while(QueueActionsData.Count != 0)
            {
                action = QueueActionsData.Dequeue();
                action.Invoke();
            }
        }
    }
}
