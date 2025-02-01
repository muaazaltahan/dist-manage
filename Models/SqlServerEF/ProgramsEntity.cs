using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class ProgramsEntity : IDataHelper<ProgramsDB>
    {
        private DBContext db;
        private ProgramsDB _table;
        public ProgramsEntity()
        {
            db = new DBContext();
        }
        public int Add(ProgramsDB table)
        {
            if (db.Database.CanConnect())
            {
                db.ProgramsDB.Add(table);
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
                db.ProgramsDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, ProgramsDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.ProgramsDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ProgramsDB Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.ProgramsDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<ProgramsDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.ProgramsDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<ProgramsDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<ProgramsDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.ProgramsDB.Where(x => x.Name.Contains(SerachItem)
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
