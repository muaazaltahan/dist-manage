using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class SectionsEntity : IDataHelper<Sections>
    {
        private DBContext db;
        private Sections _table;
        public SectionsEntity()
        {
            db = new DBContext();
        }
        public int Add(Sections table)
        {
            if (db.Database.CanConnect())
            {
                db.Sections.Add(table);
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
                db.Sections.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Sections table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Sections.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Sections Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Sections.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Sections> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Sections.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Sections> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Sections> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Sections.Where(x => x.SectionName.Contains(SerachItem)
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
