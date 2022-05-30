using System.Xml.Linq;
using System.Xml.Serialization;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class ProjectRepository : IProjectsRepository
    {
        private string _filepath;

        public ProjectRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<Project> GetAll()
        {
            var projects = GetElements();
            return projects.Select(ConvertToEntity).ToList();
        }

        public Project GetById(int id)
        {
            var project = GetElements()
                .Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(project);
        }

        public IEnumerable<Project> GetAllByLeader(int userId)
        {
            var projects = GetElements()
                .Where(u => u.Element("LeaderUserId")?.Value == userId.ToString());
            return projects.Select(ConvertToEntity).ToList();
        }

        public void Insert(Project entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfProject").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }
        private IEnumerable<XElement> GetElements()
        {
            return XDocument.Load(_filepath).Element("ArrayOfProject")?.Elements("Project");
        }

        private XElement ConvertToElement(Project project)
        {
            var entityXml = new XElement("Project");
            var id = new XElement("Id", project.Id);
            var expirationDate = new XElement("ExpirationDate", project.ExpirationDate);
            var maxHours = new XElement("MaxHours", project.MaxHours);
            var leaderUserId = new XElement("LeaderUserId", project.LeaderUserId);
            var comment = new XElement("Comment", project.Comment);
            var name = new XElement("Name", project.Name);
            entityXml.Add(id);
            entityXml.Add(expirationDate);
            entityXml.Add(maxHours);
            entityXml.Add(leaderUserId);
            entityXml.Add(comment);
            entityXml.Add(name);
            return entityXml;
        }

        private Project ConvertToEntity(XElement project)
        {
            var id = project.Element("Id")?.Value;
            var expirationDate = project.Element("ExpirationDate")?.Value;
            var maxHours = project.Element("MaxHours")?.Value;
            var leaderUserId = project.Element("LeaderUserId")?.Value;
            var comment = project.Element("Comment")?.Value;
            var name = project.Element("Name")?.Value;
            return new Project
            {
                Id = Convert.ToInt32(id),
                ExpirationDate = Convert.ToDateTime(expirationDate),
                MaxHours = Convert.ToInt32(maxHours),
                LeaderUserId = Convert.ToInt32(leaderUserId),
                Comment = comment,
                Name = name
            };
        }
    }
}
