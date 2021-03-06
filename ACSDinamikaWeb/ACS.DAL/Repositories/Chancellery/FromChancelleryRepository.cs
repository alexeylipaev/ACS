﻿using ACS.DAL.EF;
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
    public class FromChancelleryRepository : IRepository<FromChancellery>
    {
        private ACSContext db;

        public FromChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<FromChancellery> GetAll()
        {
            return db.FromChancelleries;
        }

        public FromChancellery Get(int Id)
        {
            return db.FromChancelleries.Find(Id);
        }


        public void Create(FromChancellery FromChancellery)
        {
            db.FromChancelleries.Add(FromChancellery);
        }

        public void Update(FromChancellery FromChancellery)
        {
            db.Entry(FromChancellery).State = EntityState.Modified;
        }

        public IEnumerable<FromChancellery> Find(Func<FromChancellery, Boolean> predicate)
        {
            return db.FromChancelleries.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            FromChancellery From = db.FromChancelleries.Find(Id);
            if (From != null)
                db.FromChancelleries.Remove(From);
        }
    }
}
