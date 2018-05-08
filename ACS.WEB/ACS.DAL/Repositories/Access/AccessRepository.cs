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

        public Access Get(int id)
        {
            return db.Accesses.Find(id);
        }


        public void Create(Access access, int authorId)
        {
            access.s_EditorId = authorId;
            access.s_EditDate = access.s_DateCreation;
            access.s_AuthorId = authorId;
            db.Accesses.Add(access);
        }
        public void MoveToBasket(Access access, int EditorId)
        {
            access.s_InBasket = true;
            Update(access, EditorId);
        }
        public void Update(Access access, int authorId)
        {
            access.s_EditorId = authorId;
            access.s_EditDate = DateTime.Now;
            db.Entry(access).State = EntityState.Modified;
        }

        public IEnumerable<Access> Find(Func<Access, Boolean> predicate)
        {
            return db.Accesses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Access access = db.Accesses.Find(id);
            if (access != null)
                db.Accesses.Remove(access);
        }
    }
}
