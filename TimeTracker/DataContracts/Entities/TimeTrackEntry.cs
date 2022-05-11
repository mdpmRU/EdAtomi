using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Entities
{
    public class TimeTrackEntry : BaseEntity
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }
    }
}
