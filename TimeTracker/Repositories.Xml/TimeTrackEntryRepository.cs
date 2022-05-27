using System;
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
    public class TimeTrackEntryRepository: ITimeTrackEntriesRepository
    {
        private XmlSerializer _xmlSerializer = new(typeof(List<TimeTrackEntry>));
        private string filepath = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\Projects.xml";

        public IEnumerable<TimeTrackEntry> GetAll()
        {
            //return Stubs.TimeTrackEntries.ToList().AsReadOnly();
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                return _xmlSerializer.Deserialize(fs) as List<TimeTrackEntry>;
            }
        }

        public TimeTrackEntry GetById(int id)
        {
            //return Stubs.TimeTrackEntries.Single(t => t.Id == id);
            XDocument xdoc = XDocument.Load(filepath);
            var timeTrackEntry = xdoc.Element("ArrayOfTimeTrackEntry").Elements("TimeTrackEntry").Single(u => u.Element("Id")?.Value == id.ToString());
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

        public IEnumerable<TimeTrackEntry> GetAllForUser(int userId)
        {
            return Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == userId);
        }

        public void Insert(TimeTrackEntry entity)
        {
            Stubs.TimeTrackEntries.Add(entity);
        }

        public void SaveAll(IEnumerable<TimeTrackEntry> listEntities)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fs, listEntities);
            }
        }
    }
}
