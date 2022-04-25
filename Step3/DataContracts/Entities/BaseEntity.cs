using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string Comment { get; set; } // Инфо
    }
}
