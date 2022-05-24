using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Contracts
{
    public interface ITimeTrackEntriesRepository<T> : IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAllForUser(int userId);
    }
}
