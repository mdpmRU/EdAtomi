using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using DataContracts.Entities;

namespace Business.BusinessObjects
{
    public class UserData
    {
        private Stubs _stubs = new Stubs();
        public UserData(User user)
        {
            User = user;
            
        }

        public User User { get; set ; }

        public List<TimeTrackEntry> SubmittedTime { get; set; }

        public delegate void IsChanged(string msg);
        public event IsChanged IsActiveChanged;

        public void UpdateTimeTrackEntry(List<TimeTrackEntry> list)
        {
            SubmittedTime = new List<TimeTrackEntry>(list);
            foreach (var timeTrackEntry in SubmittedTime)
            {
                _stubs.UpdateTimeTrackEntry(timeTrackEntry);
            }
            IsActiveChanged.Invoke("TimeTrackEntry list update");
        }

        
    }
}
