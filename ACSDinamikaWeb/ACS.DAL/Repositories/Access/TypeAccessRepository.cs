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
  public  class TypeAccessRepository : IRepository<TypeAccess>

    {
        private ACSContext db;

        public TypeAccessRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<TypeAccess> GetAll()
        {
            return db.TypeAccesses;
        }

        public TypeAccess Get(int id)
        {
            return db.TypeAccesses.Find(id);
        }
        public TypeAccess Get(string propertyValue)
        {
            return db.TypeAccesses.Find(propertyValue);
        }
        public TypeAccess Get(Guid guid)
        {
            return db.TypeAccesses.Find(guid);
        }

        public void Create(TypeAccess type)
        {
            db.TypeAccesses.Add(type);
        }

        public void Update(TypeAccess type)
        {
            db.Entry(type).State = EntityState.Modified;
        }

        public IEnumerable<TypeAccess> Find(Func<TypeAccess, Boolean> predicate)
        {
            return db.TypeAccesses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TypeAccess type = db.TypeAccesses.Find(id);
            if (type != null)
                db.TypeAccesses.Remove(type);
        }
    }
}
