using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        Stubs stubs = new Stubs();
        public IEnumerable<UserData> GetAllUsers()
        {
            return stubs.Users.Select(u => GetUserData(u.Id));
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return stubs.Users
                .Where(u => u.IsActive)
                .Select(u => GetUserData(u.Id));
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            return stubs.TimeTrackEntries
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(GetUserData);
        }

        public UserData GetUserData(int userID)
        {
            var user = stubs.Users.Single(u => u.Id == userID);
            var timeTrackEntries = stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
