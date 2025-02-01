using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class RequestEntity : IDataHelper<RequestDB>
    {
        private DBContext db;
        private RequestDB _table;
        public RequestEntity()
        {
            db = new DBContext();
        }
        public int Add(RequestDB table)
        {
            if (db.Database.CanConnect())
            {
                db.RequestDB.Add(table);
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
                db.RequestDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, RequestDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.RequestDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public RequestDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.RequestDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<RequestDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.RequestDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<RequestDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<RequestDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.RequestDB.Where(x => x.Notes.Contains(SerachItem)
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
