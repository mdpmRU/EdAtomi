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
        private readonly Stubs _stubs = new();
        public IEnumerable<TimeTrackEntry> GetAllTimeTrackEntry()
        {
            return _stubs.TimeTrackEntries;
        }
    }
}
