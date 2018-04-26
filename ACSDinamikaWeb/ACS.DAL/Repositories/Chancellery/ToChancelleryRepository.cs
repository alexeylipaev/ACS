using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
    class ToChancelleryRepository : IRepository<ToChancellery>
    {
        private ACSContext db;

        public ToChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ToChancellery> GetAll()
        {
            return db.ToChancelleries;
        }

        public ToChancellery Get(int id)
        {
            return db.ToChancelleries.Find(id);
        }
        public ToChancellery Get(string propertyValue)
        {
            return db.ToChancelleries.Find(propertyValue);
        }
        public ToChancellery Get(Guid guid)
        {
            return db.ToChancelleries.Find(guid);
        }
        public void Create(ToChancellery ToChancellery)
        {
            db.ToChancelleries.Add(ToChancellery);
        }

        public void Update(ToChancellery ToChancellery)
        {
            db.Entry(ToChancellery).State = EntityState.Modified;
        }

        public IEnumerable<ToChancellery> Find(Func<ToChancellery, Boolean> predicate)
        {
            return db.ToChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ToChancellery to = db.ToChancelleries.Find(id);
            if (to != null)
                db.ToChancelleries.Remove(to);
        }
    }
}
