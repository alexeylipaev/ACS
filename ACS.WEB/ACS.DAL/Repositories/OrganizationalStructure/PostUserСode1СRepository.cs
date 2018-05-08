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



        public void Create(PostEmployeeСode1С postsEmployeesСode1С, int authorId)
        {
            postsEmployeesСode1С.s_EditorId = authorId;
            postsEmployeesСode1С.s_EditDate = postsEmployeesСode1С.s_DateCreation;
            postsEmployeesСode1С.s_AuthorId = authorId;
            db.PostsEmployeesСode1С.Add(postsEmployeesСode1С);
        }

        public void MoveToBasket(PostEmployeeСode1С PostsEmployeesСode1С, int editorId)
        {
            PostsEmployeesСode1С.s_InBasket = true;
            Update(PostsEmployeesСode1С, editorId);
        }
        public void Update(PostEmployeeСode1С updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
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
