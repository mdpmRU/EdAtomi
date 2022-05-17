using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class ProjectRepository : IRepository<Project>
    {
        public IEnumerable<Project> GetAll()
        {
            var list = Stubs.Projects;
            return list as IEnumerable<Project>;
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }
    }
}
