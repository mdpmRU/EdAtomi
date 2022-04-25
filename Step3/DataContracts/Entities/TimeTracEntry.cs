using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Entities
{
    public class TimeTracEntry : BaseEntity
    {

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public DateTime Value { get; set; }

        public DateTime Date { get; set; }
    }
}
