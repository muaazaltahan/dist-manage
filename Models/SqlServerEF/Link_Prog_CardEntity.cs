using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class Link_Prog_CardEntity : IDataHelper<Link_Prog_Card>
    {
        private DBContext db;
        private Link_Prog_Card _table;
        public Link_Prog_CardEntity()
        {
            db = new DBContext();
        }
        public int Add(Link_Prog_Card table)
        {
            if (db.Database.CanConnect())
            {
                db.Link_Prog_Card.Add(table);
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
                db.Link_Prog_Card.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Link_Prog_Card table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Link_Prog_Card.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Link_Prog_Card Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_Card.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Link_Prog_Card> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_Card.ToList();
            }
            else
            {
                return null;
            }
        }


        public List<Link_Prog_Card> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_Card.Where(x =>
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
