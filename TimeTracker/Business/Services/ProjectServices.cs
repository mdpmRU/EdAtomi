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
    public class ProjectServices
    {
        private IRepository<User> _userRepository;
        private IRepository<Project> _projectRepository;
        private IRepository<TimeTrackEntry> _timeTrackEntryRepository;

        public ProjectServices(IRepository<User> u, IRepository<Project> p, IRepository<TimeTrackEntry> tte)
        {
            this._userRepository = u;
            this._projectRepository = p;
            this._timeTrackEntryRepository = tte;

        }
        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }
    }
}
