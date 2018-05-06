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

        public EmployeePassport Get(int id)
        {
            return db.EmployeesPassports.Find(id);
        }

        public void Create(EmployeePassport EmployeePassport)
        {
            db.EmployeesPassports.Add(EmployeePassport);
        }
        public void MoveToBasketEmployee(EmployeePassport EmployeePassport, int EditorId)
        {
            EmployeePassport.s_InBasket = true;
            EmployeePassport.s_EditorId = EditorId;
            Update(EmployeePassport);
        }
        public void Update(EmployeePassport EmployeePassport)
        {
            db.Entry(EmployeePassport).State = EntityState.Modified;
        }

        public IEnumerable<EmployeePassport> Find(Func<EmployeePassport, Boolean> predicate)
        {
            return db.EmployeesPassports.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            EmployeePassport EmployeePassport = db.EmployeesPassports.Find(id);
            if (EmployeePassport != null)
                db.EmployeesPassports.Remove(EmployeePassport);
        }
    }
}
