using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Business
{
    public struct DataRepository
    {
        public List<User> Users { get; set; }
        public List<Project> Projects { get; set; }
        public List<TimeTrackEntry> TimeTrackEntries { get; set; }
    }
}
