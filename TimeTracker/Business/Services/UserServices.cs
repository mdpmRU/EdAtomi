using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public delegate void ExceptionEventHandler(string msg);
        public event ExceptionEventHandler? Exception;

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
                .SelectMany(ent => Stubs.Users, (ent, us) => new { ent, us })
                .Where(@t => @t.us.Id == @t.ent.UserId)
                .Select(@t => @t.us);
            return users;
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

        public void UpdateUserData(UserData userData, int projectId, int hours, string comment = "")
        {
            try
            {
                userData.SubmitTime(projectId, hours, comment);
            }
            catch (Exception exception)
            {
                Exception.Invoke(exception.Message);
            }
        }
    }
}
