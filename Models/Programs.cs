using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class ProgramsDB
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
    }
}
