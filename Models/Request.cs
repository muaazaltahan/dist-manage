using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class Request
    {
        public int? Id { get; set; } // Primary Key

        public int UsersId { get; set; }  // Foreign Key to User

        public int AdminId { get; set; } // Foreign Key to User
        public bool Result { get; set; }
        public DateTime RequestDate { get; set; }

        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard
        public string Notes { get; set; }
        public static implicit operator RequestDB(Request req)
        {
            return new RequestDB
            {
                Id = req.Id,
                UsersId = req.UsersId,
                AdminId = req.AdminId,
                Result = req.Result,
                RequestDate = req.RequestDate,
                Link_Prog_CardId = req.Link_Prog_CardId,
                Notes = req.Notes
            };
        }
    }
    public class RequestDB
    {
        public int? Id { get; set; } // Primary Key
        public UsersDB Users { get; set; }
        public int UsersId { get; set; }  // Foreign Key to User
        public UsersDB Admin { get; set; }
        public int AdminId { get; set; } // Foreign Key to User
        public bool Result { get; set; }
        public DateTime RequestDate { get; set; }
        public Link_Prog_CardDB Link_Prog_Card { get; set; }
        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard
        public string Notes { get; set; }
    }
}
