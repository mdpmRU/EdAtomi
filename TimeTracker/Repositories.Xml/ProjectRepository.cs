using Contracts;
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

        public IEnumerable<Project> GetEntriesForUserId(int Id)
        {
            return Stubs.Projects.Where(p => p.LeaderUserId == Id);
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }
    }
}
