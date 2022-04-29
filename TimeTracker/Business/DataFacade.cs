using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services;

namespace Business
{
    public class DataFacade
    {
        public UserServices UserServices { get; set; }

        public TimeTrackEntryServices TimeTrackEntryServices { get; set; }

        public ProjectServices ProjectServices { get; set; }
    }
}
