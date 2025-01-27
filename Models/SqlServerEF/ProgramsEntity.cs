using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class ProgramsEntity : IDataHelper<Programs>
    {
        private DBContext db;
        private Programs _table;
        public ProgramsEntity()
        {
            db = new DBContext();
        }
        public int Add(Programs table)
        {
            if (db.Database.CanConnect())
            {
                db.Programs.Add(table);
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
                db.Programs.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Programs table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Programs.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Programs Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Programs.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Programs> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Programs.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Programs> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Programs> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Programs.Where(x => x.Name.Contains(SerachItem)
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
