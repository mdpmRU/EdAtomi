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
        private string _filepath;

        public TimeTrackEntryRepository(string filepath)
        {
            _filepath = filepath;
        }

        public IEnumerable<TimeTrackEntry> GetAll()
        {
            var timeTrackEntries = GetElements();
            return timeTrackEntries.Select(ConvertToEntity).ToList().AsReadOnly();
        }

        public TimeTrackEntry GetById(int id)
        {
            var timeTrackEntry = GetElements()
                .Single(t => t.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(timeTrackEntry);
        }

        public IEnumerable<TimeTrackEntry> GetAllForUser(int userId)
        {
            var timeTrackEntries = GetElements()
                .Where(t => t.Element("UserId")?.Value == userId.ToString());
            return timeTrackEntries.Select(ConvertToEntity).ToList().AsReadOnly();
        }

        public void Insert(TimeTrackEntry entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfTimeTrackEntry").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
        }

        private IEnumerable<XElement> GetElements()
        {
            return XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry");
        }

        private XElement ConvertToElement(TimeTrackEntry timeTrackEntry)
        {
            var entityXml = new XElement("TimeTrackEntry");
            var id = new XElement("Id", timeTrackEntry.Id);
            var comment = new XElement("Comment", timeTrackEntry.Comment);
            var date = new XElement("Date", timeTrackEntry.Date);
            var projectId = new XElement("ProjectId", timeTrackEntry.ProjectId);
            var userId = new XElement("UserId", timeTrackEntry.UserId);
            var value = new XElement("Value", timeTrackEntry.Value);
            entityXml.Add(id);
            entityXml.Add(comment);
            entityXml.Add(userId);
            entityXml.Add(projectId);
            entityXml.Add(value);
            entityXml.Add(date);
            return entityXml;
        }

        private TimeTrackEntry ConvertToEntity(XElement timeTrackEntry)
        {
            var id = timeTrackEntry.Element("Id")?.Value;
            var comment = timeTrackEntry.Element("Comment")?.Value;
            var date = timeTrackEntry.Element("Date")?.Value;
            var projectId = timeTrackEntry.Element("ProjectId")?.Value;
            var userId = timeTrackEntry.Element("UserId")?.Value;
            var value = timeTrackEntry.Element("Value")?.Value;
            return new TimeTrackEntry
            {
                Id = Convert.ToInt32(id),
                Comment = comment,
                Date = Convert.ToDateTime(date),
                ProjectId = Convert.ToInt32(projectId),
                UserId = Convert.ToInt32(userId),
                Value = Convert.ToInt32(value)
            };
        }
    }
}
