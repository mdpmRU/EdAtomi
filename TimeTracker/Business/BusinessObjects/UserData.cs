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

        //public void UpdateUserData(UserData userData)
        //{
        //    Stubs stubs = new Stubs();
        //    if (userData == null)
        //        return;

        //    if (User != userData.User)
        //    {
        //        User = userData.User;
        //        stubs.UpdateUser(userData.User);
        //        IsActiveChanged.Invoke();
        //    }

        //    if (SubmittedTime != userData.SubmittedTime)
        //    {
        //        SubmittedTime = userData.SubmittedTime;
        //        foreach (var TTE in SubmittedTime)
        //        {
        //            stubs.UpdateTTE(TTE);
        //        }
        //        IsActiveChanged.Invoke();
        //    }

        //}
    }
}
