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

        public void Create(EmployeePassport employeePassport, int authorId)
        {
            employeePassport.s_EditorId = authorId;
            employeePassport.s_EditDate = employeePassport.s_DateCreation;
            employeePassport.s_AuthorId = authorId;
            db.EmployeesPassports.Add(employeePassport);
        }
        public void MoveToBasket(EmployeePassport EmployeePassport, int editorId)
        {
            EmployeePassport.s_InBasket = true;
            Update(EmployeePassport, editorId);
        }
        public void Update(EmployeePassport updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
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
