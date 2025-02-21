using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=DMTest;Trusted_Connection=true");
        }
        
        public DbSet<CardsDB> CardsDB { get; set; }
        public DbSet<Link_Prog_CardDB> Link_Prog_CardDB { get; set; }
        public DbSet<Link_Prog_UserDB> Link_Prog_UserDB { get; set; }
        public DbSet<LogsDB> LogsDB { get; set; }
        public DbSet<ProgramsDB> ProgramsDB { get; set; }
        public DbSet<RequestDB> RequestDB { get; set; }
        public DbSet<SectionsDB> SectionsDB { get; set; }
        public DbSet<SectionUsersDB> SectionUsersDB { get; set; }
        public DbSet<UsersDB> UsersDB { get; set; }
    }
}
