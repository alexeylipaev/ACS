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
    public class ApplicationRoleRepository : IRepository<ApplicationRole>

    {
        private ACSContext db;

        public ApplicationRoleRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return db.ApplicationRoleRepository;
        }

        public ApplicationRole Get(int Id)
        {
            return db.ApplicationRoleRepository.Find(Id);
        }

        public void Create(ApplicationRole ApplicationRole)
        {
            db.ApplicationRoleRepository.Add(ApplicationRole);
        }

        public void Update(ApplicationRole ApplicationRole)
        {
            db.Entry(ApplicationRole).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationRole> Find(Func<ApplicationRole, Boolean> predicate)
        {
            return db.ApplicationRoleRepository.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ApplicationRole Role = db.ApplicationRoleRepository.Find(Id);
            if (Role != null)
                db.ApplicationRoleRepository.Remove(Role);
        }
    }
}
