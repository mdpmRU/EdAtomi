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

        public User User { get; set; }

        public List<TimeTrackEntry> SubmittedTime { get; set; }

        public delegate void SubmittedTimeChangedEventHandler(int submittedTime);
        public event SubmittedTimeChangedEventHandler SubmittedTimeChanged;

        public void SubmitTime(int projectId, int hours, string comment)
        {
            if (!User.IsActive)
                throw new Exception("Пользователь не активен, обновление не требуется");

            var time = new TimeTrackEntry
            {
                Comment = comment,
                Date = DateTime.Now,
                ProjectId = projectId,
                UserId = User.Id,
                Value = hours
            };
            SubmittedTime.Add(time);
            SubmittedTimeChanged?.Invoke(hours);
        }   
    }
}
