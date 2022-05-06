using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public IEnumerable<UserData> GetAllUsers()
        {
            var listUserData = new List<UserData>();
            for (var i = 1; i < Stubs.Users.Count + 1; i++)
                listUserData.Add(GetUserData(i));
            return listUserData;
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            var listUserData = Stubs.Users.Where(u => u.IsActive);
            return listUserData.Select(us => GetUserData(us.Id)).ToList();
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            var listUserData = Stubs.TimeTrackEntries.Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId);
            return listUserData.Select(GetUserData).ToList();
        }

        public UserData GetUserData(int userID)
        {
            var user = (Stubs.Users.Where(us => us.Id == userID)).First();
            var timeTrackEntries = Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
