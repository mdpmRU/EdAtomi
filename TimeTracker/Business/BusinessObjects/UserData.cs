using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using DataContracts.Entities;
using Solution;

namespace Business.BusinessObjects
{
    public class UserData
    {
        private IMediator _mediator;

        public UserData(User user, List<TimeTrackEntry> submittedTime, IMediator mediator)
        {
            User = user;
            SubmittedTime = submittedTime;
            _mediator = mediator;
            _mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);
        }

        public User User { get; private set; }

        public List<TimeTrackEntry> SubmittedTime { get; private set; }

        public event Action<int> SubmittedTimeChanged;

        public void OnSubmittedTimeChanged()
        {

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
            _mediator.RaiseSubmittedTimeChanged(this);
            SubmittedTimeChanged.Invoke(allHours);
        }
    }
}
