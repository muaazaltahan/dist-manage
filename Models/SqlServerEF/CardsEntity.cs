using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_manage.DB;
using Microsoft.EntityFrameworkCore;

namespace dist_manage.Models.SqlServerEF
{
    public class CardsEntity
    {
        private DBContext db;
        private CardsDB _table;
        public CardsEntity(DBContext db)
        {
            this.db = db;
        }
        public int Add(CardsDB table)
        {
            if (db.Database.CanConnect())
            {
                db.CardsDB.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(string Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.CardsDB.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(string Id, CardsDB table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.CardsDB.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public CardsDB Find(string Id)
        {
            if (db.Database.CanConnect())
            {
                return db.CardsDB.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<CardsDB> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.CardsDB.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<CardsDB> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<CardsDB> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.CardsDB.Where(
                   x =>  x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
