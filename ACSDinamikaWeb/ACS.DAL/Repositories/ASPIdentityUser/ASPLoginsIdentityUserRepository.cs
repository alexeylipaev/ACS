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
    class ASPLoginsIdentityUserRepository : IRepository<ASPLoginsIdentityUser>

    {
        private ACSContext db;

        public ASPLoginsIdentityUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ASPLoginsIdentityUser> GetAll()
        {
            return db.ASPLoginsIdentityUsers;
        }

        public ASPLoginsIdentityUser Get(int Id)
        {
            return db.ASPLoginsIdentityUsers.Find(Id);
        }



        public void Create(ASPLoginsIdentityUser ASPLoginsIdentityUser)
        {
            db.ASPLoginsIdentityUsers.Add(ASPLoginsIdentityUser);
        }

        public void Update(ASPLoginsIdentityUser ASPLoginsIdentityUser)
        {
            db.Entry(ASPLoginsIdentityUser).State = EntityState.Modified;
        }

        public IEnumerable<ASPLoginsIdentityUser> Find(Func<ASPLoginsIdentityUser, Boolean> predicate)
        {
            return db.ASPLoginsIdentityUsers.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ASPLoginsIdentityUser Login = db.ASPLoginsIdentityUsers.Find(Id);
            if (Login != null)
                db.ASPLoginsIdentityUsers.Remove(Login);
        }
    }
}
