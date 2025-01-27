using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class LogsEntity : IDataHelper<Logs>
    {
        private DBContext db;
        private Logs _table;
        public LogsEntity()
        {
            db = new DBContext();
        }
        public int Add(Logs table)
        {
            if (db.Database.CanConnect())
            {
                db.Logs.Add(table);
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
                db.Logs.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Logs table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Logs.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Logs Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Logs.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Logs> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Logs.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Logs> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Logs> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Logs.Where(x => x.Notes.Contains(SerachItem)
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
