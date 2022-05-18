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
        private static IRepository<TimeTrackEntry> _timeTrackEntryRepository { get; set; }

        public TimeTrackEntryServices(IRepository<TimeTrackEntry> timeTrackEntriesRepository)
        {
            _timeTrackEntryRepository = timeTrackEntriesRepository;
        }

        public IEnumerable<TimeTrackEntry> GetAllTimeTrackEntry()
        {
            return _timeTrackEntryRepository.GetAll();
        }
    }
}
