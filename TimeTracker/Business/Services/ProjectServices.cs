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
        Stubs stubs = new Stubs();
        public IEnumerable<Project> GetAllProjects()
        {
            return stubs.Projects;
        }
    }
}
