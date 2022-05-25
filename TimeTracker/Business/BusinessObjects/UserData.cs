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
        public UserData(User user, List<TimeTrackEntry> submittedTime )
        {
            User = user;
            SubmittedTime = submittedTime;
        }

        public User User { get; private set; }

        public List<TimeTrackEntry> SubmittedTime { get; private set; }

        public event Action<int> SubmittedTimeChanged;

        public void RaiseSubmittedTimeChanged(UserData userData, Dictionary<Guid, Action<UserData>> _subscriptions)
        {
            foreach (var subscriptionId in _subscriptions.Keys)
                _subscriptions[subscriptionId](userData);
        }

        public void SubmitTime(int projectId, int hours, string comment)
        {
            if (!User.IsActive)
                throw new Exception("Пользователь не активен, обновление не требуется");

            var timeTrackEntry = new TimeTrackEntry
            {
                Comment = comment,
                Date = DateTime.Now,
                ProjectId = projectId,
                UserId = User.Id,
                Value = hours
            };
            SubmittedTime.Add(timeTrackEntry);
            var allHours = SubmittedTime.Select(h => h.Value).Sum();
            SubmittedTimeChanged?.Invoke(allHours);
        }
    }
}
