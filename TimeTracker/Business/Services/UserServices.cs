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
            var user = from u in Stubs.Users where u.IsActive == true select u;
            return user;
        }

        public UserData GetUserData(int userID)
        {

            var user = (from us in Stubs.Users where us.Id == userID select us).First();
            var TTEUser= from TTE in Stubs.TimeTrackEntrys where TTE.UserId == user.Id select TTE;
            var userData = new UserData(user)
            {
                User = user,
                SubmittedTime = new List<TimeTrackEntry>(TTEUser)
            };
            return userData;
        }

        public void UpdateUserData(UserData userData)
        {
            var oldUserData = GetUserData(userData.User.Id);
            oldUserData.IsActiveChanged += Ex;

            if (oldUserData.User != userData.User)
            {
                //update user in stubs
                oldUserData.UpdateUser(userData.User);
            }

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
