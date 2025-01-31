using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class Request
    {
        public int Id { get; set; } // Primary Key

        public int UsersId { get; set; }  // Foreign Key to User

        public int AdminId { get; set; } // Foreign Key to User
        public bool Result { get; set; }
        public DateTime RequestDate { get; set; }

        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard
        public string Notes { get; set; }
    }
    public class RequestDB
    {
        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; }  // Foreign Key to User
        public Users Admin { get; set; }
        public int AdminId { get; set; } // Foreign Key to User
        public bool Result { get; set; }
        public DateTime RequestDate { get; set; }
        public Link_Prog_Card Link_Prog_Card { get; set; }
        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard
        public string Notes { get; set; }
    }
}
