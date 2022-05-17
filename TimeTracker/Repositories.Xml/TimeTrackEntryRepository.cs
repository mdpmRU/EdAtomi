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
    public class TimeTrackEntryRepository: IRepository<TimeTrackEntry>
    {
        public IEnumerable<TimeTrackEntry> GetAll()
        {
            return Stubs.TimeTrackEntries.ToList().AsReadOnly();
        }

        public void Insert(TimeTrackEntry entity)
        {
            Stubs.TimeTrackEntries.Add(entity);
        }
    }
}
