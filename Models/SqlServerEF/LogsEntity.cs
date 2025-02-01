using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class LogsEntity : IDataHelper<LogsDB>
    {
        private DBContext db;
        private LogsDB _table;
        public LogsEntity()
        {
            db = new DBContext();
        }
        public int Add(LogsDB table)
        {
            if (db.Database.CanConnect())
            {
                db.LogsDB.Add(table);
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
                db.LogsDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, LogsDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.LogsDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public LogsDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.LogsDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<LogsDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.LogsDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<LogsDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<LogsDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.LogsDB.Where(x => x.Notes.Contains(SerachItem)
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
