using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dist_manage.DB
{
    public class SectionUsers
    {
        public int? Id { get; set; } // Primary Key

        public int UsersId { get; set; } // Foreign Key to User

        public int SectionsId { get; set; } // Foreign Key to Section
        public static implicit operator SectionUsersDB(SectionUsers s)
        {
            return new SectionUsersDB
            {
                Id = s.Id,
                UsersId = s.UsersId,
                SectionsId = s.SectionsId,
            };
        }

    }
    public class SectionUsersDB
    {
        public int? Id { get; set; } // Primary Key
        public UsersDB Users { get; set; }
        public int UsersId { get; set; } // Foreign Key to User
        public SectionsDB Sections { get; set; }
        public int SectionsId { get; set; } // Foreign Key to Section

    }
}
