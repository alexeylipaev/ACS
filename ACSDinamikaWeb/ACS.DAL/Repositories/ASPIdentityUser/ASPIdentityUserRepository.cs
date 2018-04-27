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

        public ASPIdentityUser Get(int Id)
        {
            return db.ASPIdentityUsers.Find(Id);
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

        public void Delete(int Id)
        {
            ASPIdentityUser IdentityUser = db.ASPIdentityUsers.Find(Id);
            if (IdentityUser != null)
                db.ASPIdentityUsers.Remove(IdentityUser);
        }
    }
}
