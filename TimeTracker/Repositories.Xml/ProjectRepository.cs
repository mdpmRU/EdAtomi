using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class ProjectRepository : IRepository<Project>
    {
        public IEnumerable<Project> GetAll()
        {
            return Stubs.Projects.ToList().AsReadOnly();
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }
    }
}
