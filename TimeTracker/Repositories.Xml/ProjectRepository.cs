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
            var listProjects = XDocument.Load(_filepath).Element("ArrayOfProject").Elements("Project");
            return listProjects.Select(ConvertToEntity).ToList();
        }

        public Project GetById(int id)
        {
            var project = XDocument.Load(_filepath).Element("ArrayOfProject").Elements("Project")
                .Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(project);
        }

        public IEnumerable<Project> GetAllByLeader(int userId)
        {
            var enumerableProjectsXMl = XDocument.Load(_filepath).Element("ArrayOfProject")?.Elements("Project")
                .Where(u => u.Element("LeaderUserId")?.Value == userId.ToString());
            return enumerableProjectsXMl.Select(ConvertToEntity).ToList();
        }

        public void Insert(Project entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfProject").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }

        private XElement ConvertToElement(Project project)
        {
            var entityXML = new XElement("Project");
            var Id = new XElement("Id", project.Id);
            var ExpirationDate = new XElement("ExpirationDate", project.ExpirationDate);
            var MaxHours = new XElement("MaxHours", project.MaxHours);
            var LeaderUserId = new XElement("LeaderUserId", project.LeaderUserId);
            var Comment = new XElement("Comment", project.Comment);
            var Name = new XElement("Name", project.Name);
            entityXML.Add(Id);
            entityXML.Add(ExpirationDate);
            entityXML.Add(MaxHours);
            entityXML.Add(LeaderUserId);
            entityXML.Add(Comment);
            entityXML.Add(Name);
            return entityXML;
        }

        private Project ConvertToEntity(XElement project)
        {
            var Id = project.Element("Id")?.Value;
            var ExpirationDate = project.Element("ExpirationDate")?.Value;
            var MaxHours = project.Element("MaxHours")?.Value;
            var LeaderUserId = project.Element("LeaderUserId")?.Value;
            var Comment = project.Element("Comment")?.Value;
            var Name = project.Element("Name")?.Value;
            return new Project
            {
                Id = Convert.ToInt32(Id),
                ExpirationDate = Convert.ToDateTime(ExpirationDate),
                MaxHours = Convert.ToInt32(MaxHours),
                LeaderUserId = Convert.ToInt32(LeaderUserId),
                Comment = Comment,
                Name = Name
            };
        }
    }
}
