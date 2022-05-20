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
        private IRepository<TimeTrackEntry> _timeTrackEntriesRepository;

        public UserServices(IRepository<User> usersesRepository, IRepository<TimeTrackEntry> timeTrackEntriesesRepository)
        {
            _usersRepository = usersesRepository;
            _timeTrackEntriesRepository = timeTrackEntriesesRepository;
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

        public UserData GetUserById(int userID)
        {
            var user = _usersRepository.GetAll().Single(u => u.Id == userID);
            var timeTrackEntries = _timeTrackEntriesRepository.GetAll().Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }

        private UserData GetUserData(User user)
        {
            var timeTrackEntries = _timeTrackEntriesRepository.GetAll().Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
