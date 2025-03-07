﻿using System;
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
    public enum UserRole
    {
        Admin = 1,
        User = 2,
        Moderator = 3
    }
    public class UsersDB
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string Notes { get; set; }
    }
}
