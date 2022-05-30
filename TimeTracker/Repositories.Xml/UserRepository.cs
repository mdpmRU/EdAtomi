using System.ComponentModel;
using System.Xml.Serialization;
using Business.BusinessObjects;
using Business.Services;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;
using Business;
using DataContracts.Entities.Enumerations;

namespace Repositories.Xml
{
    public class UserRepository : IRepository<User>
    {
        private XmlSerializer _xmlSerializer = new(typeof(List<User>));
        private string _filepath;

        public UserRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<User> GetAll()
        {
            var listUsers = XDocument.Load(_filepath).Element("ArrayOfUser").Elements("User");
            return listUsers.Select(ConvertToEntity).ToList();
        }

        public User GetById(int id)
        {
            var user = XDocument.Load(_filepath).Element("ArrayOfUser").Elements("User").Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(user);
        }

        public void Insert(User entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfUser").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }

        private XElement ConvertToElement(User user)
        {
            var entityXML = new XElement("User");
            var Id = new XElement("Id", user.Id);
            var Username = new XElement("Username", user.Username);
            var Password = new XElement("Password", user.Password);
            var FullName = new XElement("FullName", user.FullName);
            var IsActive = new XElement("IsActive", user.IsActive);
            var AccessRole = new XElement("AccessRole", user.AccessRole);
            var Comment = new XElement("Comment", user.Comment);
            entityXML.Add(Id);
            entityXML.Add(Username);
            entityXML.Add(Password);
            entityXML.Add(FullName);
            entityXML.Add(IsActive);
            entityXML.Add(AccessRole);
            entityXML.Add(Comment);
            return entityXML;
        }

        private User ConvertToEntity(XElement user)
        {
            var Id = user.Element("Id")?.Value;
            var Username = user.Element("Username")?.Value;
            var Password = user.Element("Password")?.Value;
            var FullName = user.Element("FullName")?.Value;
            var IsActive = user.Element("IsActive")?.Value;
            var AccessRole = user.Element("AccessRole")?.Value;
            var Comment = user.Element("Comment")?.Value;
            return new User
            {
                Id = Convert.ToInt32(Id),
                AccessRole = Enum.Parse<Role>(AccessRole),
                FullName = FullName,
                Comment = Comment,
                IsActive = Convert.ToBoolean(IsActive),
                Password = Password,
                Username = Username
            };
        }
    }
}