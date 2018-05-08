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


        public void Create(PostNameEmployee postNameUser, int authorId)
        {
            postNameUser.s_EditorId = authorId;
            postNameUser.s_EditDate = postNameUser.s_DateCreation;
            postNameUser.s_AuthorId = authorId;
            db.PostsEmployees.Add(postNameUser);
        }
        public void MoveToBasket(PostNameEmployee name, int editorId)
        {
            name.s_InBasket = true;
            Update(name,editorId);
        }
        public void Update(PostNameEmployee updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
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
