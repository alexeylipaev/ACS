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
    class ASPIdentityUserRepository : IRepository<ASPIdentityUser>

    {
        private ACSContext db;

        public ASPIdentityUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ASPIdentityUser> GetAll()
        {
            return db.ASPIdentityUsers;
        }

        public ASPIdentityUser Get(int id)
        {
            return db.ASPIdentityUsers.Find(id);
        }
        public ASPIdentityUser Get(Guid guid)
        {
            return db.ASPIdentityUsers.Find(guid);
        }

        public void Create(ASPIdentityUser ASPIdentityUser)
        {
            db.ASPIdentityUsers.Add(ASPIdentityUser);
        }

        public void Update(ASPIdentityUser ASPIdentityUser)
        {
            db.Entry(ASPIdentityUser).State = EntityState.Modified;
        }

        public IEnumerable<ASPIdentityUser> Find(Func<ASPIdentityUser, Boolean> predicate)
        {
            return db.ASPIdentityUsers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ASPIdentityUser IdentityUser = db.ASPIdentityUsers.Find(id);
            if (IdentityUser != null)
                db.ASPIdentityUsers.Remove(IdentityUser);
        }
    }
}
