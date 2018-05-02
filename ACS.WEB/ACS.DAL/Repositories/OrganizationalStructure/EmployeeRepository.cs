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

    public class EmployeeRepository : IRepository<Employee>
    {
        private ACSContext db;
        
        public EmployeeRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee Get(int Id)
        {
            return db.Employees.Find(Id);
        }



        public void Create(Employee user)
        {
            db.Employees.Add(user);
        }

        public void Update(Employee Employee)
        {
            db.Entry(Employee).State = EntityState.Modified;
        }

        public IEnumerable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            return db.Employees.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            Employee user = db.Employees.Find(Id);
            if (user != null)
                db.Employees.Remove(user);
        }
    }
}
