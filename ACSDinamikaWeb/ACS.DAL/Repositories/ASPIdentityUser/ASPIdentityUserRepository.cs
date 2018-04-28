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
    class ApplicationUsersRepository : IRepository<ApplicationUser>

    {
        private ACSContext db;

        public ApplicationUsersRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.ApplicationUsersRepository;
        }

        public ApplicationUser Get(int Id)
        {
            return db.ApplicationUsersRepository.Find(Id);
        }

        public void Create(ApplicationUser ASPIdentityUser)
        {
            db.ApplicationUsersRepository.Add(ASPIdentityUser);
        }

        public void Update(ApplicationUser ASPIdentityUser)
        {
            db.Entry(ASPIdentityUser).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate)
        {
            return db.ApplicationUsersRepository.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ApplicationUser IdentityUser = db.ApplicationUsersRepository.Find(Id);
            if (IdentityUser != null)
                db.ApplicationUsersRepository.Remove(IdentityUser);
        }
    }
}
