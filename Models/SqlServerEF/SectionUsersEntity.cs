using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class SectionUsersEntity : IDataHelper<SectionUsers>
    {
        private DBContext db;
        private SectionUsers _table;
        public SectionUsersEntity()
        {
            db = new DBContext();
        }
        public int Add(SectionUsers table)
        {
            if (db.Database.CanConnect())
            {
                db.SectionUsers.Add(table);
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
                db.SectionUsers.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, SectionUsers table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.SectionUsers.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public SectionUsers Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsers.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<SectionUsers> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsers.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<SectionUsers> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<SectionUsers> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionUsers.Where(x => x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
