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
    class UserPassportRepository : IRepository<UserPassport>
    {
        private ACSContext db;

        public UserPassportRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserPassport> GetAll()
        {
            return db.PassportDataUsers;
        }

        public UserPassport Get(int Id)
        {
            return db.PassportDataUsers.Find(Id);
        }

        public void Create(UserPassport UserPassport)
        {
            db.PassportDataUsers.Add(UserPassport);
        }

        public void Update(UserPassport UserPassport)
        {
            db.Entry(UserPassport).State = EntityState.Modified;
        }

        public IEnumerable<UserPassport> Find(Func<UserPassport, Boolean> predicate)
        {
            return db.PassportDataUsers.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            UserPassport UserPassport = db.PassportDataUsers.Find(Id);
            if (UserPassport != null)
                db.PassportDataUsers.Remove(UserPassport);
        }
    }
}
