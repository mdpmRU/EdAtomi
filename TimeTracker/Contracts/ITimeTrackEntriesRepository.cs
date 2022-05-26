using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Contracts
{
    public interface ITimeTrackEntriesRepository : IRepository<TimeTrackEntry>
    {
        public IEnumerable<TimeTrackEntry> GetAllForUser(int userId);
    }
}
