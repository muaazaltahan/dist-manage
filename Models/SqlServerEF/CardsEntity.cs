using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dist_managet.DB;

namespace dist_manage.Models.SqlServerEF
{
    public class CardsEntity : IDataHelper<Cards>
    {
        private DBContext db;
        private Cards _table;
        public CardsEntity()
        {
            db = new DBContext();
        }
        public int Add(Cards table)
        {
            if (db.Database.CanConnect())
            {
                db.Cards.Add(table);
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
                db.Cards.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Cards table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Cards.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Cards Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Cards.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Cards> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Cards.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Cards> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Cards> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Cards.Where(
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
