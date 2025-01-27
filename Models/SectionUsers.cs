using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_managet.DB
{
    public class SectionUsers
    {
        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public Sections Sections { get; set; }
        public int SectionsId { get; set; } // Foreign Key to Section

    }
    public class SectionUsersDB
    {
        public int Id { get; set; } // Primary Key
        public Users Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public Sections Sections { get; set; }
        public int SectionsId { get; set; } // Foreign Key to Section

    }
}
