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
    class DataEntityRepository : IRepository<DataEntity>
    {
        private ACSContext db;

        public DataEntityRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<DataEntity> GetAll()
        {
            return db.DataEntityis;
        }

        public DataEntity Get(int id)
        {
            return db.DataEntityis.Find(id);
        }

        public DataEntity Get(Guid guid)
        {
            return db.DataEntityis.Find(guid);
        }

        public void Create(DataEntity DataEntity)
        {
            db.DataEntityis.Add(DataEntity);
        }

        public void Update(DataEntity DataEntity)
        {
            db.Entry(DataEntity).State = EntityState.Modified;
        }

        public IEnumerable<DataEntity> Find(Func<DataEntity, Boolean> predicate)
        {
            return db.DataEntityis.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            DataEntity DataEntity = db.DataEntityis.Find(id);
            if (DataEntity != null)
                db.DataEntityis.Remove(DataEntity);
        }
    }
}
