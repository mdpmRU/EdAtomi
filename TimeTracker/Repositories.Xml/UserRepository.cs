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
        private string _filepath;

        public UserRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<User> GetAll()
        {
            var enumerableUsersXMl = GetEnumerable();
            return enumerableUsersXMl.Select(ConvertToEntity).ToList();
        }

        public User GetById(int id)
        {
            var user = GetEnumerable()
                .Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(user);
        }

        public void Insert(User entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfUser").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }

        private IEnumerable<XElement> GetEnumerable()
        {
            return XDocument.Load(_filepath).Element("ArrayOfUser").Elements("User");
        }

        private XElement ConvertToElement(User user)
        {
            var entityXml = new XElement("User");
            var id = new XElement("Id", user.Id);
            var username = new XElement("Username", user.Username);
            var password = new XElement("Password", user.Password);
            var fullName = new XElement("FullName", user.FullName);
            var isActive = new XElement("IsActive", user.IsActive);
            var accessRole = new XElement("AccessRole", user.AccessRole);
            var comment = new XElement("Comment", user.Comment);
            entityXml.Add(id);
            entityXml.Add(username);
            entityXml.Add(password);
            entityXml.Add(fullName);
            entityXml.Add(isActive);
            entityXml.Add(accessRole);
            entityXml.Add(comment);
            return entityXml;
        }

        private User ConvertToEntity(XElement user)
        {
            var id = user.Element("Id")?.Value;
            var username = user.Element("Username")?.Value;
            var password = user.Element("Password")?.Value;
            var fullName = user.Element("FullName")?.Value;
            var isActive = user.Element("IsActive")?.Value;
            var accessRole = user.Element("AccessRole")?.Value;
            var comment = user.Element("Comment")?.Value;
            return new User
            {
                Id = Convert.ToInt32(id),
                AccessRole = Enum.Parse<Role>(accessRole),
                FullName = fullName,
                Comment = comment,
                IsActive = Convert.ToBoolean(isActive),
                Password = password,
                Username = username
            };
        }
    }
}