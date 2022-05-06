﻿using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public IEnumerable<UserData> GetAllUsers()
        {
            return Stubs.Users.Select(us => GetUserData(us.Id));
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return Stubs.Users
                .Where(u => u.IsActive)
                .Select(us => GetUserData(us.Id));
        }

        public IEnumerable<UserData> GetUsersForProject(int idProject, int time = 1)
        {
            return Stubs.TimeTrackEntries
                .Where(ent => ent.ProjectId == idProject && ent.Value >= time)
                .Select(ent => ent.UserId)
                .Select(GetUserData);
        }

        public UserData GetUserData(int userID)
        {
            var user = (Stubs.Users.Where(us => us.Id == userID)).Single();
            var timeTrackEntries = Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
