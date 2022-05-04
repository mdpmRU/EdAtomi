using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public IEnumerable<User> GetAllUsers()
        {
            return Stubs.Users;
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            var user = Stubs.Users.Where(u => u.IsActive);
            return user;
        }

        public IEnumerable<User> GetUsersForProject(int idProject, int time = 1)
        {
            var users = Stubs.TimeTrackEntries.Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .SelectMany(ent => Stubs.Users, (ent, us) => new {ent, us})
                .Where(@t => @t.us.Id == @t.ent.UserId)
                .Select(@t => @t.us);
            return users;
        }

        public UserData GetUserData(int userID)
        {

            var user = (Stubs.Users.Where(us => us.Id == userID)).First();
            var timeTrackEntryUser = Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                User = user,
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntryUser)
            };
            return userData;
        }

        public void UpdateUserData(UserData userData)
        {
            var oldUserData = GetUserData(userData.User.Id);
            oldUserData.IsActiveChanged += Ex;

            if (oldUserData != userData)
            {
                //update list in stubs
                oldUserData.UpdateTimeTrackEntry(userData.SubmittedTime);
            }
        }

        public void Ex(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
