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
   public class ChancelleryRepository : IRepository<Chancellery>

    {
        private ACSContext db;

        public ChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Chancellery> GetAll()        
        {
            return db.Chancelleries;
        }

        public Chancellery Get(int Id)
        {
            return db.Chancelleries.Find(Id);
        }

        public void Create(Chancellery Chancellery)
        {
            db.Chancelleries.Add(Chancellery);
        }

        public void Update(Chancellery chancellery)
        {
            db.Entry(chancellery).State = EntityState.Modified;
        }

        public IEnumerable<Chancellery> Find(Func<Chancellery, Boolean> predicate)
        {
            return db.Chancelleries.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            Chancellery book = db.Chancelleries.Find(Id);
            if (book != null)
                db.Chancelleries.Remove(book);
        }
    }
}
