using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class UsersEntity : IDataHelper<UsersDB>
    {
        private DBContext db;
        private UsersDB _table;
        public UsersEntity()
        {
            db = new DBContext();
        }
        public int Add(UsersDB table)
        {
            if (db.Database.CanConnect())
            {
                db.UsersDB.Add(table);
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
                db.UsersDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, UsersDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.UsersDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public UsersDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.UsersDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<UsersDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.UsersDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<UsersDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<UsersDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.UsersDB.Where(x => x.Name.Contains(SerachItem)
                || x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
