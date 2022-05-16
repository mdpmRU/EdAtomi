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
    public class RepXML<T> : IRepository<T> where T : BaseEntity
    { 
        public IEnumerable<T> GetAll()
        {
            //var formatter = new XmlSerializer(typeof(List<T>));
            //using var fs = new FileStream($"{(typeof(T).Name)}.xml", FileMode.OpenOrCreate);
            //IEnumerable<T>? list = formatter.Deserialize(fs) as List<T>;
            if (typeof(T).Name == "User")
            {
                var list = Stubs.Users;
                return list as IEnumerable<T>;
            }

            if (typeof(T).Name == "Project")
            {
                var list = Stubs.Projects;
                return list as IEnumerable<T>;
            }
            else
            {
                var list = Stubs.TimeTrackEntries;
                return list as IEnumerable<T>;
            }

        }

        public void Insert(T entity)
        {
            //var xmlSerializer = new XmlSerializer(typeof(T));
            //using var fs = new FileStream($"{(typeof(T).Name)}.xml", FileMode.OpenOrCreate);
            //xmlSerializer.Serialize(fs, entity);
        }
    }
}