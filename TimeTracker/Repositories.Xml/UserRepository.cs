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
            var user = xdoc.Element("ArrayOfUser").Elements("User").Single(u => u.Element("Id")?.Value == id.ToString());
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
                    AccessRole = ConvertRole(AccessRole),
                    FullName = FullName,
                    Comment = Comment,
                    IsActive = Convert.ToBoolean(IsActive),
                    Password = Password,
                    Username = Username
                };
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

        private Role ConvertRole(string role)
        {
            var r = Enum.Parse<Role>(role);
            return r;
        }
    }
}