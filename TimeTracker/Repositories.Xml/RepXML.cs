using System.ComponentModel;
using System.Xml.Serialization;
using Business.BusinessObjects;
using Business.Services;
using Contracts;
using DataContracts;
using DataContracts.Entities;
using System.ComponentModel;
using System.Xml;

namespace Repositories.Xml
{
    public class RepXML<T> : IRepository<T> where T : BaseEntity
    { 
        public IEnumerable<T>? GetAll()
        {
            var formatter = new XmlSerializer(typeof(List<T>));
            using var fs = new FileStream($"{(typeof(T).Name)}.xml", FileMode.OpenOrCreate);
            IEnumerable<T>? list = formatter.Deserialize(fs) as List<T>;
            return list;
        }

        public void Insert(T obj)
        {
            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var fs = new FileStream("Users2.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs, obj, ns);
        }
    }
}