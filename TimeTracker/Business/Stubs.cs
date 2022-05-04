﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

namespace DataContracts
{
    public class Stubs
    {
        public User UpdateUser(User user)
        {
            if (user != null)
                return user;
            return user;
        }
        public TimeTrackEntry UpdateTimeTrackEntry(TimeTrackEntry timeTrackEntry)
        {
            if (timeTrackEntry != null)
                return timeTrackEntry;
            return timeTrackEntry;
        }


        public static List<Project> Projects = new List<Project>()
        {
            new()
            {
                Id = 1,
                ExpirationDate = new DateTime(2015, 7, 20),
                MaxHours = 12,
                LeaderUserId = 1,
                Name = "Raz"

            },
            new()
            {
                Id = 2,
                ExpirationDate = new DateTime(2015, 8, 20),
                MaxHours = 13,
                LeaderUserId = 2,
                Name = "Dva"

            },


        };

        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                AccessRole = Role.User,
                FullName = "Human1",
                IsActive = true,
                Password = "123",
                Username = "Man"

            },
            new User()
            {
                Id = 2,
                AccessRole = Role.User,
                FullName = "Human2",
                IsActive = false,
                Password = "123",
                Username = "Wowan"
            },
            new User()
            {
                Id = 3,
                AccessRole = Role.User,
                FullName = "Human3",
                IsActive = true,
                Password = "123",
                Username = "Wowan"
            }

        };

        public static List<TimeTrackEntry> TimeTrackEntries = new List<TimeTrackEntry>()
        {
            new TimeTrackEntry()
            {
                Id = 1,
                Comment = "Успешно1",
                Date = DateTime.Today,
                ProjectId = 1,
                UserId = 1,
                Value = 12
            },
            new TimeTrackEntry()
            {
                Id = 2,
                Comment = "Успешно 3",
                Date = DateTime.Today,
                ProjectId = 1,
                UserId = 3,
                Value = 12
            },
            new TimeTrackEntry()
            {
            Id = 2,
            Comment = "Неудачно",
            Date = DateTime.Today,
            ProjectId = 2,
            UserId = 2,
            Value = 13
            }
        };

    }
}