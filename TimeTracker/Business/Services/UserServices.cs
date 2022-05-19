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
        private IRepository<User> _userRepository;
        private IRepository<TimeTrackEntry> _timeTrackEntryRepository;

        public UserServices(IRepository<User> usersRepository, IRepository<TimeTrackEntry> timeTrackEntriesRepository)
        {
            _userRepository = usersRepository;
            _timeTrackEntryRepository = timeTrackEntriesRepository;
        }

        public IEnumerable<UserData> GetAllUsers()
        {
            //return _userRepository.GetAll().Select(u => GetUserDataById(u.Id));
            return _userRepository.GetAll().Select(u => u).Select(GetUserData);
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return _userRepository.GetAll()
                .Where(u => u.IsActive)
                .Select(GetUserData);
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            return Stubs.TimeTrackEntries
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(GetUserDataById);
        }

        public UserData GetUserDataById(int userID)
        {
            var user = _userRepository.GetAll().Single(u => u.Id == userID);
            var timeTrackEntries = _timeTrackEntryRepository.GetAll().Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }

        private UserData GetUserData(User user)
        {
            var timeTrackEntries = _timeTrackEntryRepository.GetAll().Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
