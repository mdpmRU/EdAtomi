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
        private string _filepath;

        public ProjectRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<Project> GetAll()
        {
            //return Stubs.Projects.ToList().AsReadOnly();
            using (FileStream fs = new FileStream(_filepath, FileMode.OpenOrCreate))
            {
                return _xmlSerializer.Deserialize(fs) as List<Project>;
            }
        }

        public Project GetById(int id)
        {
            //return Stubs.Projects.Single(p => p.Id == id);
            var project = XDocument.Load(_filepath).Element("ArrayOfProject").Elements("Project").Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(project);

        }

        public IEnumerable<Project> GetAllByLeader(int userId)
        {
            //return Stubs.Projects.Where(p => p.LeaderUserId == userId);
            var listProject = new List<Project>();
            var listProjectXMl = XDocument.Load(_filepath).Element("ArrayOfProject")
                ?.Elements("Project")
                .Where(u => u.Element("LeaderUserId")?.Value == userId.ToString());
            foreach (var project in listProjectXMl)
            {
                listProject.Add(ConvertToEntity(project));
            }
            return listProject;
        }

        public void Insert(Project entity)
        {
            Stubs.Projects.Add(entity);
        }

        public void SaveAll(IEnumerable<Project> listEntities)
        {
            using (FileStream fs = new FileStream(_filepath, FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fs, listEntities);
            }
        }

        private Project ConvertToEntity(XElement project)
        {
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
                Comment = Comment
            };
        }
    }
}
