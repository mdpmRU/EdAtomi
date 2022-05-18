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
        private static IRepository<Project> _projectRepository { get; set; }

        public ProjectServices(IRepository<Project> projectsRepository)
        {
            _projectRepository = projectsRepository;

        }
        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }
    }
}
