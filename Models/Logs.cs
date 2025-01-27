using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_managet.DB
{
    public class Logs
    {
        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public DateTime LogDate { get; set; }
        public string Notes { get; set; }
        public Link_Prog_Card Link_Prog_Card { get; set; }
        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard

    }
    public class LogsDB
    {
        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public DateTime LogDate { get; set; }
        public string Notes { get; set; }
        public Link_Prog_Card Link_Prog_Card { get; set; }
        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard

    }
}
