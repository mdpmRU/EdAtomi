﻿using System;
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
            var timeTrackEntry = XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry")
                .Single(u => u.Element("Id")?.Value == id.ToString());
            return ConvertToEntity(timeTrackEntry);
        }

        public IEnumerable<TimeTrackEntry> GetAllForUser(int userId)
        {
            var enumerableTimeTrackEntriesXml = XDocument.Load(_filepath).Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry")
                .Where(u => u.Element("UserId")?.Value == userId.ToString());
            return enumerableTimeTrackEntriesXml.Select(ConvertToEntity).ToList();
        }

        public void Insert(TimeTrackEntry entity)
        {
            var xdoc = XDocument.Load(_filepath);
            xdoc.Element("ArrayOfTimeTrackEntry").Add(ConvertToElement(entity));
            xdoc.Save(_filepath);
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
