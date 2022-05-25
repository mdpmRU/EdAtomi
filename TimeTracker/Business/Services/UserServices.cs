using System.Collections;
using System.ComponentModel.DataAnnotations;
using Business.BusinessObjects;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using Solution;

namespace Business.Services
{
    public class UserServices
    {
        private IRepository<User> _usersRepository;
        private ITimeTrackEntriesRepository _timeTrackEntriesRepository;
        private IMediator _mediator;

        public UserServices(IRepository<User> usersRepository, ITimeTrackEntriesRepository timeTrackEntriesRepository, IMediator mediator)
        {
            _usersRepository = usersRepository;
            _timeTrackEntriesRepository = timeTrackEntriesRepository;
            _mediator = mediator;
            _mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);
        }

        public void OnSubmittedTimeChanged()
        {

        }

        public IEnumerable<UserData> GetAllUsers()
        {
            return _usersRepository.GetAll().Select(GetUserData);
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return _usersRepository.GetAll()
                .Where(u => u.IsActive)
                .Select(GetUserData);
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            return _timeTrackEntriesRepository.GetAll()
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(GetUserById);
        }

        public UserData GetUserById(int userId)
        {
            var user = _usersRepository.GetById(userId);
            return GetUserData(user);
        }

        private UserData GetUserData(User user)
        {
            var timeTrackEntries = _timeTrackEntriesRepository.GetAllForUser(user.Id).ToList();
            var userData = new UserData(user, timeTrackEntries, _mediator);
            return userData;
        }
    }
}
