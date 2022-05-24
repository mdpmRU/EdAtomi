using System.Collections;
using System.ComponentModel.DataAnnotations;
using Business.BusinessObjects;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        private IRepository<User> _usersRepository;
        private ITimeTrackEntriesRepository _timeTrackEntriesRepository;

        public UserServices(IRepository<User> usersRepository, ITimeTrackEntriesRepository timeTrackEntriesRepository)
        {
            _usersRepository = usersRepository;
            _timeTrackEntriesRepository = timeTrackEntriesRepository;
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
            var timeTrackEntries = _timeTrackEntriesRepository.GetAllForUser(user.Id).ToList();
            var userData = new UserData(user, timeTrackEntries);
            return userData;
        }

        private UserData GetUserData(User user)
        {
            var timeTrackEntries = _timeTrackEntriesRepository.GetAllForUser(user.Id).ToList();
            var userData = new UserData(user, timeTrackEntries);
            return userData;
        }
    }
}
