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
            var list = Stubs.TimeTrackEntries;
            return list as IEnumerable<TimeTrackEntry>;
        }
        public void Insert(TimeTrackEntry entity)
        {
            Stubs.TimeTrackEntries.Add(entity);
        }

    }
}
