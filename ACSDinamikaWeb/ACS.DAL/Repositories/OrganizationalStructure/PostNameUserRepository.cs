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
    public class PostNameUserRepository : IRepository<PostNameUser>
    {
        private ACSContext db;

        public PostNameUserRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<PostNameUser> GetAll()
        {
            return db.PostUsers;
        }

        public PostNameUser Get(int Id)
        {
            return db.PostUsers.Find(Id);
        }


        public void Create(PostNameUser PostNameUser)
        {
            db.PostUsers.Add(PostNameUser);
        }

        public void Update(PostNameUser name)
        {
            db.Entry(name).State = EntityState.Modified;
        }

        public IEnumerable<PostNameUser> Find(Func<PostNameUser, Boolean> predicate)
        {
            return db.PostUsers.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            PostNameUser namePost = db.PostUsers.Find(Id);
            if (namePost != null)
                db.PostUsers.Remove(namePost);
        }
    }
}
