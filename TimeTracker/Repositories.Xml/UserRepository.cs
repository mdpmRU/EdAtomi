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
        private XmlSerializer _xmlSerializerU = new(typeof(User));
        private string filepath = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\Users.xml";

        public IEnumerable<User> GetAll()
        {
            //return Stubs.Users.ToList().AsReadOnly();
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                return _xmlSerializer.Deserialize(fs) as List<User>;
            }
        }

        public User GetById(int id)
        {
            XDocument xdoc = XDocument.Load(filepath);

            //return Stubs.Users.Single(u => u.Id == id);
            //using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            //{
            var userXElement = xdoc.Element("ArrayOfUser").Elements("User").Single(u => u.Element("Id")?.Value == id.ToString());
                var Id = userXElement.Element("Id")?.Value;
                var Username = userXElement.Element("Username")?.Value;
                var Password = userXElement.Element("Password")?.Value;
                var FullName = userXElement.Element("FullName")?.Value;
                var IsActive = userXElement.Element("IsActive")?.Value;
                var AccessRole = userXElement.Element("IsActive")?.Value;
                var Comment = userXElement.Element("IsActive")?.Value;
                return new User
                {
                    Id = Convert.ToInt32(Id), AccessRole = Role.Admin, FullName = FullName, Comment = Comment,
                    IsActive = Convert.ToBoolean(IsActive), Password = Password, Username = Username
                };
            //}
        }
        
        public void Insert(User entity)
        {
            Stubs.Users.Add(entity);
        }

        public void SaveAll(IEnumerable<User> listEntities)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fs, listEntities);
            }
        }
    }
}