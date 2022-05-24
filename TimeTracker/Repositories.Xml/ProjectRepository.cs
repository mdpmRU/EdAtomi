﻿using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class ProjectRepository : IRepositoryForUserID<Project>
    {
        public IEnumerable<Project> GetAll()
        {
            return Stubs.Projects.ToList().AsReadOnly();
        }

        public Project GetById(int id)
        {
            return Stubs.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetAllForUser(int userId)
        {
            return Stubs.Projects.Where(p => p.LeaderUserId == userId);
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }
    }
}
