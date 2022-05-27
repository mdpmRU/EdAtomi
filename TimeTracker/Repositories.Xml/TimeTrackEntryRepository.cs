using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return Stubs.TimeTrackEntries.Single(t => t.Id == id);
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
