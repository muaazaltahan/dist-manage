using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class SectionsEntity : IDataHelper<SectionsDB>
    {
        private DBContext db;
        private SectionsDB _table;
        public SectionsEntity()
        {
            db = new DBContext();
        }
        public int Add(SectionsDB table)
        {
            if (db.Database.CanConnect())
            {
                db.SectionsDB.Add(table);
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
                db.SectionsDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, SectionsDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.SectionsDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public SectionsDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionsDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<SectionsDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.SectionsDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<SectionsDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<SectionsDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.SectionsDB.Where(x => x.SectionName.Contains(SerachItem)
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
