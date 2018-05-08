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


        public void Create(DataEntity dataEntity, int editorId)
        {
            dataEntity.s_EditDate = dataEntity.s_DateCreation;
            dataEntity.s_AuthorId = editorId;
            dataEntity.s_EditorId = editorId;
            db.DataEntityis.Add(dataEntity);
        }
        public void MoveToBasket(DataEntity dataEntity, int editorId)
        {
            dataEntity.s_InBasket = true;
            
            Update(dataEntity, editorId);
        }
        public void Update(DataEntity dataEntity, int editorId)
        {
            dataEntity.s_EditorId = editorId;
            dataEntity.s_EditDate = DateTime.Now;
            db.Entry(dataEntity).State = EntityState.Modified;
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
