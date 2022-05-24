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
        private IProjectsRepository<Project> _projectsRepository;

        public ProjectServices(IProjectsRepository<Project> projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _projectsRepository.GetAll();
        }
    }
}
