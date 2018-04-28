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

    public class UserRepository : IRepository<User>
    {
        private ACSContext db;
        
        public UserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.DataUsers;
        }

        public User Get(int Id)
        {
            return db.DataUsers.Find(Id);
        }



        public void Create(User user)
        {
            db.DataUsers.Add(user);
        }

        public void Update(User User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.DataUsers.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            User user = db.DataUsers.Find(Id);
            if (user != null)
                db.DataUsers.Remove(user);
        }
    }
}
