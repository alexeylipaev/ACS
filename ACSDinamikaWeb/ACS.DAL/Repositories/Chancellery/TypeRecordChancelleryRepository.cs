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
    class TypeRecordChancelleryRepository : IRepository<TypeRecordChancellery>

    {
        private ACSContext db;

        public TypeRecordChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<TypeRecordChancellery> GetAll()
        {
            return db.TypeRecordChancelleries;
        }

        public TypeRecordChancellery Get(int Id)
        {
            return db.TypeRecordChancelleries.Find(Id);
        }

        public void Create(TypeRecordChancellery type)
        {
            db.TypeRecordChancelleries.Add(type);
        }

        public void Update(TypeRecordChancellery type)
        {
            db.Entry(type).State = EntityState.Modified;
        }

        public IEnumerable<TypeRecordChancellery> Find(Func<TypeRecordChancellery, Boolean> predicate)
        {
            return db.TypeRecordChancelleries.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            TypeRecordChancellery type = db.TypeRecordChancelleries.Find(Id);
            if (type != null)
                db.TypeRecordChancelleries.Remove(type);
        }
    }
}
