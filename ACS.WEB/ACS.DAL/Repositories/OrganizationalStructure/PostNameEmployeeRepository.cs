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
    public class PostNameEmployeeRepository : IRepository<PostNameEmployee>
    {
        private ACSContext db;

        public PostNameEmployeeRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<PostNameEmployee> GetAll()
        {
            return db.PostsEmployees;
        }

        public PostNameEmployee Get(int Id)
        {
            return db.PostsEmployees.Find(Id);
        }


        public void Create(PostNameEmployee PostNameUser)
        {
            db.PostsEmployees.Add(PostNameUser);
        }

        public void Update(PostNameEmployee name)
        {
            db.Entry(name).State = EntityState.Modified;
        }

        public IEnumerable<PostNameEmployee> Find(Func<PostNameEmployee, Boolean> predicate)
        {
            return db.PostsEmployees.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            PostNameEmployee namePost = db.PostsEmployees.Find(Id);
            if (namePost != null)
                db.PostsEmployees.Remove(namePost);
        }
    }
}
