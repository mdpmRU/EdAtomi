using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class TimeTrackEntryServices
    {
        readonly Stubs _stubs = new Stubs();
        public IEnumerable<TimeTrackEntry> GetAllTimeTrackEntry()
        {
            return _stubs.TimeTrackEntries;
        }
    }
}
