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
    public class PostsEmployeesСode1СRepository : IRepository<PostsEmployeesСode1С>
    {
        private ACSContext db;

        public PostsEmployeesСode1СRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<PostsEmployeesСode1С> GetAll()
        {
            return db.PostsEmployeesСode1С;
        }

        public PostsEmployeesСode1С Get(int Id)
        {
            return db.PostsEmployeesСode1С.Find(Id);
        }



        public void Create(PostsEmployeesСode1С PostsEmployeesСode1С)
        {
            db.PostsEmployeesСode1С.Add(PostsEmployeesСode1С);
        }

        public void Update(PostsEmployeesСode1С PostsEmployeesСode1С)
        {
            db.Entry(PostsEmployeesСode1С).State = EntityState.Modified;
        }

        public IEnumerable<PostsEmployeesСode1С> Find(Func<PostsEmployeesСode1С, Boolean> predicate)
        {
            return db.PostsEmployeesСode1С.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            PostsEmployeesСode1С code = db.PostsEmployeesСode1С.Find(Id);
            if (code != null)
                db.PostsEmployeesСode1С.Remove(code);
        }
    }
}
