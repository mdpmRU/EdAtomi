﻿using Business.BusinessObjects;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class UserServices
    {
        public IEnumerable<UserData> GetAllUsers()
        {
            return Stubs.Users.Select(u => GetUserData(u.Id));
        }

        public IEnumerable<UserData> GetAllActiveUsers()
        {
            return Stubs.Users
                .Where(u => u.IsActive)
                .Select(u => GetUserData(u.Id));
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
            var user = Stubs.Users.Single(u => u.Id == userID);
            var timeTrackEntries = Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == user.Id);
            var userData = new UserData(user)
            {
                SubmittedTime = new List<TimeTrackEntry>(timeTrackEntries)
            };
            return userData;
        }
    }
}
