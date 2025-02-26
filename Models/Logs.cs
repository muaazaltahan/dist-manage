using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class Logs
    {
        public int? Id { get; set; } // Primary Key

        public int UsersId { get; set; } // Foreign Key to User
        public int CardId { get; set; }
        public DateTime LogDate { get; set; }
        public string Notes { get; set; }

        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard
        public static implicit operator LogsDB(Logs db)
        {
            return new LogsDB
            {
                Id = db.Id,
                UsersId = db.UsersId,
                LogDate = db.LogDate,
                Notes = db.Notes,
                Link_Prog_CardId = db.Link_Prog_CardId
            };
        }

    }
    public class LogsDB
    {
        public int? Id { get; set; } // Primary Key
        public UsersDB Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public DateTime LogDate { get; set; }
        public string Notes { get; set; }
        public Link_Prog_CardDB Link_Prog_Card { get; set; }
        public int Link_Prog_CardId { get; set; } // Foreign Key to LinkProgCard

    }
}
