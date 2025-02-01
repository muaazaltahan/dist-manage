using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class Link_Prog_CardEntity : IDataHelper<Link_Prog_CardDB>
    {
        private DBContext db;
        private Link_Prog_CardDB _table;
        public Link_Prog_CardEntity()
        {
            db = new DBContext();
        }
        public int Add(Link_Prog_CardDB table)
        {
            if (db.Database.CanConnect())
            {
                db.Link_Prog_CardDB.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.Link_Prog_CardDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Link_Prog_CardDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Link_Prog_CardDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Link_Prog_CardDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_CardDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Link_Prog_CardDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_CardDB.ToList();
            }
            else
            {
                return null;
            }
        }


        public List<Link_Prog_CardDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_CardDB.Where(x =>
                x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
