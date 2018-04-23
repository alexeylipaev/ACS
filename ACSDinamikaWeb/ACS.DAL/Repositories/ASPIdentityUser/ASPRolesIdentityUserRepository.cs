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
    class ASPRolesIdentityUserRepository : IRepository<ASPRolesIdentityUser>

    {
        private ACSContext db;

        public ASPRolesIdentityUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ASPRolesIdentityUser> GetAll()
        {
            return db.ASPRolesIdentityUsers;
        }

        public ASPRolesIdentityUser Get(int id)
        {
            return db.ASPRolesIdentityUsers.Find(id);
        }

        public void Create(ASPRolesIdentityUser ASPRolesIdentityUser)
        {
            db.ASPRolesIdentityUsers.Add(ASPRolesIdentityUser);
        }

        public void Update(ASPRolesIdentityUser ASPRolesIdentityUser)
        {
            db.Entry(ASPRolesIdentityUser).State = EntityState.Modified;
        }

        public IEnumerable<ASPRolesIdentityUser> Find(Func<ASPRolesIdentityUser, Boolean> predicate)
        {
            return db.ASPRolesIdentityUsers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ASPRolesIdentityUser Role = db.ASPRolesIdentityUsers.Find(id);
            if (Role != null)
                db.ASPRolesIdentityUsers.Remove(Role);
        }
    }
}
