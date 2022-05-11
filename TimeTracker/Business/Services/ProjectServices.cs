using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using DataContracts.Entities;

namespace Business.Services
{
    public class ProjectServices
    {
        public IEnumerable<Project> GetAllProjects()
        {
            return Stubs.Projects;
        }
    }
}
