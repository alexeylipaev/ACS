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
   public class ApplicationUserRepository : IRepository<ApplicationUser>

    {
        private ACSContext db;

        public ApplicationUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.ApplicationUserRepository;
        }

        public ApplicationUser Get(int Id)
        {
            return db.ApplicationUserRepository.Find(Id);
        }

        public void Create(ApplicationUser ApplicationUser)
        {
            db.ApplicationUserRepository.Add(ApplicationUser);
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            db.Entry(ApplicationUser).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate)
        {
            return db.ApplicationUserRepository.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ApplicationUser IdentityUser = db.ApplicationUserRepository.Find(Id);
            if (IdentityUser != null)
                db.ApplicationUserRepository.Remove(IdentityUser);
        }
    }
}
