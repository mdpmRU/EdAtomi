using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Contracts
{
    public interface IProjectsRepository : IRepository<Project>
    {
        public IEnumerable<Project> GetAllByLeader(int userId);
    }
}
