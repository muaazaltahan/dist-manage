using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_managet.DB
{
    public class Link_Prog_Card
    {
        public int Id { get; set; } // Primary Key
        public Programs Programs { get; set; }
        public int ProgramsId { get; set; } // Foreign Key to Program
        public Cards Cards { get; set; }
        public int CardsId { get; set; } // Foreign Key to Card

    }
    public class Link_Prog_CardDB
    {
        public int Id { get; set; } // Primary Key
        public Programs Programs { get; set; }
        public int ProgramsId { get; set; } // Foreign Key to Program
        public Cards Cards { get; set; }
        public int CardsId { get; set; } // Foreign Key to Card

    }

}
