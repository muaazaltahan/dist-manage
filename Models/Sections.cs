using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class SectionsDB
    {
        public int Id { get; set; } // Primary Key
        public string SectionName { get; set; }
        public string Notes { get; set; }
    }
}
