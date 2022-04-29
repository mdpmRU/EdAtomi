using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Business.BusinessObjects
{
    public class ProjectTeam
    {
        public ProjectTeam(Project project)
        {
            Project = project;

        }
        public Project Project { get; set; }
        public List<User> Team { get; set; }
    }
}
