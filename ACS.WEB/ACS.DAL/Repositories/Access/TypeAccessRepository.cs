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


        public void Create(TypeAccess type, int authorId)
        {
            type.s_EditorId = authorId;
            type.s_EditDate = type.s_DateCreation;
            type.s_AuthorId = authorId;
            db.TypeAccesses.Add(type);
        }
        public void MoveToBasket(TypeAccess type, int EditorId)
        {
            type.s_InBasket = true;
            Update(type,EditorId);
        }
        public void Update(TypeAccess type, int authorId)
        {
            type.s_EditorId = authorId;
            type.s_EditDate = DateTime.Now;
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
