using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class TimeTrackEntryRepository : ITimeTrackEntriesRepository
    {
        private XmlSerializer _xmlSerializer = new(typeof(List<TimeTrackEntry>));
        private string _filepath;

        public TimeTrackEntryRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<TimeTrackEntry> GetAll()
        {
            var listTimeTrackEntries = XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry");
            return listTimeTrackEntries.Select(ConvertToEntity).ToList();
        }

        public TimeTrackEntry GetById(int id)
        {
            var timeTrackEntry = XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry").Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(timeTrackEntry);
        }

        public IEnumerable<TimeTrackEntry> GetAllForUser(int userId)
        {
            var listTimeTrackEntryXml = XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry").Where(u => u.Element("UserId")?.Value == userId.ToString());
            return listTimeTrackEntryXml.Select(ConvertToEntity).ToList();
        }

        public void Insert(TimeTrackEntry entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfTimeTrackEntry").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }

        private XElement ConvertToElement(TimeTrackEntry timeTrackEntry)
        {
            var entityXML = new XElement("TimeTrackEntry");
            var Id = new XElement("Id", timeTrackEntry.Id);
            var Comment = new XElement("Comment", timeTrackEntry.Comment);
            var Date = new XElement("Date", timeTrackEntry.Date);
            var ProjectId = new XElement("ProjectId", timeTrackEntry.ProjectId);
            var UserId = new XElement("UserId", timeTrackEntry.UserId);
            var Value = new XElement("Value", timeTrackEntry.Value);
            entityXML.Add(Id);
            entityXML.Add(Comment);
            entityXML.Add(UserId);
            entityXML.Add(ProjectId);
            entityXML.Add(Value);
            entityXML.Add(Date);
            return entityXML;
        }

        private TimeTrackEntry ConvertToEntity(XElement timeTrackEntry)
        {
            var Id = timeTrackEntry.Element("Id")?.Value;
            var Comment = timeTrackEntry.Element("Comment")?.Value;
            var Date = timeTrackEntry.Element("Date")?.Value;
            var ProjectId = timeTrackEntry.Element("ProjectId")?.Value;
            var UserId = timeTrackEntry.Element("UserId")?.Value;
            var Value = timeTrackEntry.Element("Value")?.Value;

            return new TimeTrackEntry
            {
                Id = Convert.ToInt32(Id),
                Comment = Comment,
                Date = Convert.ToDateTime(Date),
                ProjectId = Convert.ToInt32(ProjectId),
                UserId = Convert.ToInt32(UserId),
                Value = Convert.ToInt32(Value)
            };
        }
    }
}
