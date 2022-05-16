using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public IEnumerable<UserData> GetAllUsers(DataRepository rep)
        {
            return rep.Users.Select(u => GetUserData(rep,u.Id));
        }

        public IEnumerable<UserData> GetAllActiveUsers(DataRepository rep)
        {
            return rep.Users
                .Where(u => u.IsActive)
                .Select(u => GetUserData(rep,u.Id));
        }

        public IEnumerable<UserData> GetUsersForProject(DataRepository rep, int idProject, int time = 1)
        {
            return Stubs.TimeTrackEntries
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(i => GetUserData(rep,i));
        }

        public UserData GetUserData(DataRepository rep, int userID)
        {
            var user = rep.Users.Single(u => u.Id == userID);
            var timeTrackEntries = rep.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
