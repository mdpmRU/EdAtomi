using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Repositories.Xml
{
    public class TimeTrackEntryRepository: IRepositoryForUserID<TimeTrackEntry>
    {
        public IEnumerable<TimeTrackEntry> GetAll()
        {
            return Stubs.TimeTrackEntries.ToList().AsReadOnly();
        }

        public TimeTrackEntry GetById(int id)
        {
            return Stubs.TimeTrackEntries.Single(t => t.Id == id);
        }

        public IEnumerable<TimeTrackEntry> GetAllForUserId(int userId)
        {
            return Stubs.TimeTrackEntries.Where(timeTrackEntry => timeTrackEntry.UserId == userId);
        }

        public void Insert(TimeTrackEntry entity)
        {
            Stubs.TimeTrackEntries.Add(entity);
        }
    }
}
