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
        IQueryable<User> All { get; }
        User CurrentUser { get; }
        void InsertOrUpdate(User user);
        void Remove(User user);
        void Save();
    }
}
