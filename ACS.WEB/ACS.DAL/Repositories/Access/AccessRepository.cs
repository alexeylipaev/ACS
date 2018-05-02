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
    class AccessRepository : IRepository<Access>

    {
        private ACSContext db;

        public AccessRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Access> GetAll()
        {
            return db.Accesses;
        }

        public Access Get(int Id)
        {
            return db.Accesses.Find(Id);
        }


        public void Create(Access Access)
        {
            db.Accesses.Add(Access);
        }

        public void Update(Access access)
        {
            db.Entry(access).State = EntityState.Modified;
        }

        public IEnumerable<Access> Find(Func<Access, Boolean> predicate)
        {
            return db.Accesses.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            Access access = db.Accesses.Find(Id);
            if (access != null)
                db.Accesses.Remove(access);
        }
    }
}
