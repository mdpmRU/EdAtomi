using System.Xml.Serialization;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class ProjectRepository : IProjectsRepository
    {
        private XmlSerializer _xmlSerializer = new(typeof(List<Project>));
        private string filepath = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\Projects.xml";

        public IEnumerable<Project> GetAll()
        {
            //return Stubs.Projects.ToList().AsReadOnly();
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                return _xmlSerializer.Deserialize(fs) as List<Project>;
            }
        }

        public Project GetById(int id)
        {
            return Stubs.Projects.Single(p => p.Id == id);
        }

        public IEnumerable<Project> GetAllByLeader(int userId)
        {
            return Stubs.Projects.Where(p => p.LeaderUserId == userId);
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }

        public void SaveAll(IEnumerable<Project> listEntities)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fs, listEntities);
            }
        }
    }
}
