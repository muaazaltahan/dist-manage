using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dist_manage.DB
{
    public class Users
    {
       [Key]
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Notes { get; set; }
    }
    public class UsersDB
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Notes { get; set; }
    }
}
