using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class UsersEntity : IDataHelper<Users>
    {
        private DBContext db;
        private Users _table;
        public UsersEntity()
        {
            db = new DBContext();
        }
        public int Add(Users table)
        {
            if (db.Database.CanConnect())
            {
                db.Users.Add(table);
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
                db.Users.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Users table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Users.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Users Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Users.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Users> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Users.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Users> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Users> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Users.Where(x => x.Name.Contains(SerachItem)
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
