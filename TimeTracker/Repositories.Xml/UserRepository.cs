using System.ComponentModel;
using System.Xml.Serialization;
using Business.BusinessObjects;
using Business.Services;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using System.ComponentModel;
using System.Xml;
using Business;

namespace Repositories.Xml
{
    public class UserRepository : IRepository<User>
    {
        public IEnumerable<User> GetAll()
        {
            return Stubs.Users.ToList().AsReadOnly();
        }

        public void Insert(User entity)
        {
            Stubs.Users.Add(entity);
        }
    }
}