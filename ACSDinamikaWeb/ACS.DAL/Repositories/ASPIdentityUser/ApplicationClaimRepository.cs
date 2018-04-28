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
    public class ApplicationClaimRepository : IRepository<ApplicationClaim>

    {
        private ACSContext db;

        public ApplicationClaimRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationClaim> GetAll()
        {
            return db.ApplicationClaims;
        }

        public ApplicationClaim Get(int Id)
        {
            return db.ApplicationClaims.Find(Id);
        }

        public void Create(ApplicationClaim ApplicationClaim)
        {
            db.ApplicationClaims.Add(ApplicationClaim);
        }

        public void Update(ApplicationClaim ApplicationClaim)
        {
            db.Entry(ApplicationClaim).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationClaim> Find(Func<ApplicationClaim, Boolean> predicate)
        {
            return db.ApplicationClaims.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            ApplicationClaim Claim = db.ApplicationClaims.Find(Id);
            if (Claim != null)
                db.ApplicationClaims.Remove(Claim);
        }
    }
}
