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

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }



        public void Create(Employee user, int authorId)
        {
            user.s_EditorId = authorId;
            user.s_EditDate = user.s_DateCreation;
            user.s_AuthorId = authorId;
            db.Employees.Add(user);
        }

        public void Update(Employee updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
        }
        public void MoveToBasket(Employee Employee, int editorId)
        {
            Employee.s_InBasket = true;
            Update(Employee,editorId);
        }

        


        public IEnumerable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            return db.Employees.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Employee user = db.Employees.Find(id);
            if (user != null)
                db.Employees.Remove(user);
        }
    }
}
