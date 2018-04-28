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
    class ApplicationRolesRepository : IRepository<ApplicationUser>

    {
        private ACSContext db;

        public ApplicationRolesRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.ApplicationRolesRepository;
        }

        public ApplicationUser Get(int Id)
        {
            return db.ApplicationRolesRepository.Find(Id);
        }



        public void Create(ApplicationUser ApplicationUser)
        {
            db.ApplicationRolesRepository.Add(ApplicationUser);
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            db.Entry(ApplicationUser).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate)
        {
            return db.ApplicationRolesRepository.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ApplicationUser Role = db.ApplicationRolesRepository.Find(Id);
            if (Role != null)
                db.ApplicationRolesRepository.Remove(Role);
        }
    }
}
