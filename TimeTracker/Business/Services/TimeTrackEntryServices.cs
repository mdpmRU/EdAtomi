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
        private IRepository<TimeTrackEntry> _timeTrackEntryRepository;

        public TimeTrackEntryServices(IRepository<TimeTrackEntry> timeTrackEntriesRepository)
        {
            _timeTrackEntryRepository = timeTrackEntriesRepository;
        }

        public IEnumerable<TimeTrackEntry> GetAllTimeTrackEntries()
        {
            return _timeTrackEntryRepository.GetAll();
        }
    }
}
