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
    public class PostsEmployeesСode1СRepository : IRepository<PostEmployeeСode1С>
    {
        private ACSContext db;

        public PostsEmployeesСode1СRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<PostEmployeeСode1С> GetAll()
        {
            return db.PostsEmployeesСode1С;
        }

        public PostEmployeeСode1С Get(int id)
        {
            return db.PostsEmployeesСode1С.Find(id);
        }



        public void Create(PostEmployeeСode1С PostsEmployeesСode1С)
        {
            db.PostsEmployeesСode1С.Add(PostsEmployeesСode1С);
        }

        public void MoveToBasketEmployee(PostEmployeeСode1С PostsEmployeesСode1С, int EditorId)
        {
            PostsEmployeesСode1С.s_InBasket = true;
            PostsEmployeesСode1С.s_EditorId = EditorId;
            Update(PostsEmployeesСode1С);
        }
        public void Update(PostEmployeeСode1С PostsEmployeesСode1С)
        {
            db.Entry(PostsEmployeesСode1С).State = EntityState.Modified;
        }

        public IEnumerable<PostEmployeeСode1С> Find(Func<PostEmployeeСode1С, Boolean> predicate)
        {
            return db.PostsEmployeesСode1С.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PostEmployeeСode1С code = db.PostsEmployeesСode1С.Find(id);
            if (code != null)
                db.PostsEmployeesСode1С.Remove(code);
        }
    }
}
