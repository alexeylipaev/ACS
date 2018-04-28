using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Interfaces
{
    interface IUserRepository
    {
        IQueryable<Employee> All { get; }
        Employee CurrentUser { get; }
        void InsertOrUpdate(Employee user);
        void Remove(Employee user);
        void Save();
    }
}
