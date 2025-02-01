using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class Link_Prog_UserEntity : IDataHelper<Link_Prog_UserDB>
    {
        private DBContext db;
        private Link_Prog_UserDB _table;
        public Link_Prog_UserEntity()
        {
            db = new DBContext();
        }
        public int Add(Link_Prog_UserDB table)
        {
            if (db.Database.CanConnect())
            {
                db.Link_Prog_UserDB.Add(table);
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
                db.Link_Prog_UserDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Link_Prog_UserDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Link_Prog_UserDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Link_Prog_UserDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_UserDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Link_Prog_UserDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_UserDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Link_Prog_UserDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Link_Prog_UserDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Link_Prog_UserDB.Where(x => 
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
