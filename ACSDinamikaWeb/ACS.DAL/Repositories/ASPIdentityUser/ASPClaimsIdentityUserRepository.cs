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
    class ASPClaimsIdentityUserRepository : IRepository<ASPClaimsIdentityUser>

    {
        private ACSContext db;

        public ASPClaimsIdentityUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ASPClaimsIdentityUser> GetAll()
        {
            return db.ASPClaimsIdentityUsers;
        }

        public ASPClaimsIdentityUser Get(int id)
        {
            return db.ASPClaimsIdentityUsers.Find(id);
        }
        public ASPClaimsIdentityUser Get(Guid guid)
        {
            return db.ASPClaimsIdentityUsers.Find(guid);
        }


        public void Create(ASPClaimsIdentityUser ASPClaimsIdentityUser)
        {
            db.ASPClaimsIdentityUsers.Add(ASPClaimsIdentityUser);
        }

        public void Update(ASPClaimsIdentityUser ASPClaimsIdentityUser)
        {
            db.Entry(ASPClaimsIdentityUser).State = EntityState.Modified;
        }

        public IEnumerable<ASPClaimsIdentityUser> Find(Func<ASPClaimsIdentityUser, Boolean> predicate)
        {
            return db.ASPClaimsIdentityUsers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ASPClaimsIdentityUser Claim = db.ASPClaimsIdentityUsers.Find(id);
            if (Claim != null)
                db.ASPClaimsIdentityUsers.Remove(Claim);
        }
    }
}
