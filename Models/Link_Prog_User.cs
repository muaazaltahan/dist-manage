using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class Link_Prog_User
    {
       
        public int Id { get; set; } // Primary Key
        public int UsersId { get; set; }  // Foreign Key to User
        public int ProgramsId { get; set; } // Foreign Key to Program

    }
    public class Link_Prog_UserDB
    {

        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; }  // Foreign Key to User
        public Programs Programs { get; set; }
        public int ProgramsId { get; set; } // Foreign Key to Program

    }
}
