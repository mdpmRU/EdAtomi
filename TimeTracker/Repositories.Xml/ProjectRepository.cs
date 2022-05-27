using System.Xml.Linq;
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
            //return Stubs.Projects.Single(p => p.Id == id);
            XDocument xdoc = XDocument.Load(filepath);
            var project = xdoc.Element("ArrayOfProject").Elements("Project").Single(u => u.Element("Id")?.Value == id.ToString());
            var Id = project.Element("Id")?.Value;
            var ExpirationDate = project.Element("ExpirationDate")?.Value;
            var MaxHours = project.Element("ExpirationDate")?.Value;
            var LeaderUserId = project.Element("ExpirationDate")?.Value;
            var Comment = project.Element("IsActive")?.Value;
            var Name = project.Element("Name")?.Value;
            return new Project
            {
                Id = Convert.ToInt32(Id),
                ExpirationDate = Convert.ToDateTime(ExpirationDate),
                MaxHours = Convert.ToInt32(MaxHours),
                LeaderUserId = Convert.ToInt32(LeaderUserId),
                Name = Name,
                Comment = Comment,
            };
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
