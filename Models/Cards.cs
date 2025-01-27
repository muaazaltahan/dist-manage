using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_managet.DB
{
    public class Cards
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Sectionid { get; set; } // Foreign Key to Section
        public string Address { get; set; }
        public int Members { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
    }
    public class CardsDB
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }

        public Sections Section { get; set; }
        public int Sectionid { get; set; } // Foreign Key to Section
        public string Address { get; set; }
        public int Members { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
    }
}
