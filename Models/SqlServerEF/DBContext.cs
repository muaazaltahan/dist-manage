using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.//SQLServer;Database=dist_manageDB;Trusted_Connection=true");
        }
        
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Link_Prog_Card> Link_Prog_Card { get; set; }
        public DbSet<Link_Prog_User> Link_Prog_User { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<SectionUsers> SectionUsers { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
