using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class TimeTrackEntryServices
    {
        private ITimeTrackEntriesRepository<TimeTrackEntry> _timeTrackEntriesRepository;

        public TimeTrackEntryServices(ITimeTrackEntriesRepository<TimeTrackEntry> timeTrackEntriesRepository)
        {
            _timeTrackEntriesRepository = timeTrackEntriesRepository;
        }

        public IEnumerable<TimeTrackEntry> GetAllTimeTrackEntries()
        {
            return _timeTrackEntriesRepository.GetAll();
        }
    }
}
