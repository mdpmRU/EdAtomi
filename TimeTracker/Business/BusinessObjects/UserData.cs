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
        public UserData(User user)
        {
            User = user;
            
        }

        private Stubs stubs = new Stubs();
        public User User { get; set ; }

        public List<TimeTrackEntry> SubmittedTime { get; set; }

        public delegate void IsChanged(string msg);
        public event IsChanged IsActiveChanged;

        public void UpdateUser(User user)
        {
            stubs.UpdateUser(user);
            IsActiveChanged.Invoke("User update");
        }

        public void UpdateTimeTrackEntry(List<TimeTrackEntry> list)
        {
            SubmittedTime = new List<TimeTrackEntry>(list);
            foreach (var TTE in SubmittedTime)
            {
                stubs.UpdateTTE(TTE);
            }
            IsActiveChanged.Invoke("TimeTrackEntry list update");
        }

        
    }
}
