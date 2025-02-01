using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class SectionUsersEntity : IDataHelper<SectionUsersDB>
    {
        private DBContext db;
        private SectionUsersDB _table;
        public SectionUsersEntity()
        {
            db = new DBContext();
        }
        public int Add(SectionUsersDB table)
        {
            if (db.Database.CanConnect())
            {
                db.SectionUsersDB.Add(table);
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
                db.SectionUsersDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, SectionUsersDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.SectionUsersDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public SectionUsersDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsersDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<SectionUsersDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsersDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<SectionUsersDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<SectionUsersDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsersDB.Where(x => x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
