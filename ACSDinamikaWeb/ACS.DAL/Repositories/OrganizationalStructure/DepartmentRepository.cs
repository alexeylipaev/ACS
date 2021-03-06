﻿using ACS.DAL.EF;
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
  public  class DepartmentRepository : IRepository<Department>
    {
        private ACSContext db;

        public DepartmentRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public Department Get(int Id)
        {
            return db.Departments.Find(Id);
        }



        public void Create(Department Department)
        {
            db.Departments.Add(Department);
        }

        public void Update(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
        }

        public IEnumerable<Department> Find(Func<Department, Boolean> predicate)
        {
            return db.Departments.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            Department department = db.Departments.Find(Id);
            if (department != null)
                db.Departments.Remove(department);
        }
    }
}
