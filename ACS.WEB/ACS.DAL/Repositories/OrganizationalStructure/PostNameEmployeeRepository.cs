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

        public PostNameEmployee Get(int id)
        {
            return db.PostsEmployees.Find(id);
        }


        public void Create(PostNameEmployee PostNameUser)
        {
            db.PostsEmployees.Add(PostNameUser);
        }
        public void MoveToBasketEmployee(PostNameEmployee name, int EditorId)
        {
            name.s_InBasket = true;
            name.s_EditorId = EditorId;
            Update(name);
        }
        public void Update(PostNameEmployee name)
        {
            db.Entry(name).State = EntityState.Modified;
        }

        public IEnumerable<PostNameEmployee> Find(Func<PostNameEmployee, Boolean> predicate)
        {
            return db.PostsEmployees.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PostNameEmployee namePost = db.PostsEmployees.Find(id);
            if (namePost != null)
                db.PostsEmployees.Remove(namePost);
        }
    }
}
