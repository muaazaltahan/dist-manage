using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class Link_Prog_Card
    {
        public int Id { get; set; } // Primary Key
        public int ProgramsId { get; set; } // Foreign Key to Program
        public string CardsId { get; set; } // Foreign Key to Card
        public static implicit operator Link_Prog_CardDB(Link_Prog_Card db)
        {
            return new Link_Prog_CardDB { Id = db.Id, ProgramsId = db.ProgramsId, CardsId = db.CardsId };
        }

    }
    public class Link_Prog_CardDB
    {
        public int Id { get; set; } // Primary Key
        public ProgramsDB Programs { get; set; }
        public int ProgramsId { get; set; } // Foreign Key to Program
        public CardsDB Cards { get; set; }
        public string CardsId { get; set; } // Foreign Key to Card

    }

}
