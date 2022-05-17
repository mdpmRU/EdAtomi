using Business.BusinessObjects;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        private static IRepository<User> _userRepository { get; set; }
        private static IRepository<TimeTrackEntry> _timeTrackEntryRepository { get; set; }

        public UserServices(IRepository<User> u, IRepository<Project> p, IRepository<TimeTrackEntry> tte)
        {
            _userRepository = u;
            _timeTrackEntryRepository = tte;
        }

        public IEnumerable<UserData> GetAllUsers()
        {
            return _userRepository.GetAll().Select(u => GetUserData(u.Id));
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return _userRepository.GetAll()
                .Where(u => u.IsActive)
                .Select(u => GetUserData(u.Id));
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            return Stubs.TimeTrackEntries
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(i => GetUserData(i));
        }

        public UserData GetUserData(int userID)
        {
            var user = _userRepository.GetAll().Single(u => u.Id == userID);
            var timeTrackEntries = _timeTrackEntryRepository.GetAll().Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
