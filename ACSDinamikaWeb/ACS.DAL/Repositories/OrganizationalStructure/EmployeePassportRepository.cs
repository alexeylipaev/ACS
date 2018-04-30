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
    class EmployeePassportRepository : IRepository<EmployeePassport>
    {
        private ACSContext db;

        public EmployeePassportRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<EmployeePassport> GetAll()
        {
            return db.EmployeesPassports;
        }

        public EmployeePassport Get(int Id)
        {
            return db.EmployeesPassports.Find(Id);
        }

        public void Create(EmployeePassport UserPassport)
        {
            db.EmployeesPassports.Add(UserPassport);
        }

        public void Update(EmployeePassport UserPassport)
        {
            db.Entry(UserPassport).State = EntityState.Modified;
        }

        public IEnumerable<EmployeePassport> Find(Func<EmployeePassport, Boolean> predicate)
        {
            return db.EmployeesPassports.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            EmployeePassport UserPassport = db.EmployeesPassports.Find(Id);
            if (UserPassport != null)
                db.EmployeesPassports.Remove(UserPassport);
        }
    }
}
