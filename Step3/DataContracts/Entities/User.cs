using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enumerations;

namespace DataContracts.Entities
{
    internal class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public Role AccessRole;
    }
}
    