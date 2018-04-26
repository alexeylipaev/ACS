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
    public class PostUserСode1СRepository : IRepository<PostUserСode1С>
    {
        private ACSContext db;

        public PostUserСode1СRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<PostUserСode1С> GetAll()
        {
            return db.PostUserСode1С;
        }

        public PostUserСode1С Get(int id)
        {
            return db.PostUserСode1С.Find(id);
        }

        public PostUserСode1С Get(Guid guid)
        {
            return db.PostUserСode1С.Find(guid);
        }

        public void Create(PostUserСode1С PostUserСode1С)
        {
            db.PostUserСode1С.Add(PostUserСode1С);
        }

        public void Update(PostUserСode1С PostUserСode1С)
        {
            db.Entry(PostUserСode1С).State = EntityState.Modified;
        }

        public IEnumerable<PostUserСode1С> Find(Func<PostUserСode1С, Boolean> predicate)
        {
            return db.PostUserСode1С.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PostUserСode1С code = db.PostUserСode1С.Find(id);
            if (code != null)
                db.PostUserСode1С.Remove(code);
        }
    }
}
