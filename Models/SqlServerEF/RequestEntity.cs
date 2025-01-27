using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class RequestEntity : IDataHelper<Request>
    {
        private DBContext db;
        private Request _table;
        public RequestEntity()
        {
            db = new DBContext();
        }
        public int Add(Request table)
        {
            if (db.Database.CanConnect())
            {
                db.Request.Add(table);
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
                db.Request.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Request table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Request.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Request Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Request.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Request> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Request.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Request> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Request> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Request.Where(x => x.Notes.Contains(SerachItem)
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
