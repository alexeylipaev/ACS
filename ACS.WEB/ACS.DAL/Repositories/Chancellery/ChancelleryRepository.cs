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
   public class ChancelleryRepository : IRepository<Chancellery>

    {
        private ACSContext db;

        public ChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Chancellery> GetAll()        
        {
            return db.Chancelleries;
        }

        public Chancellery Get(int id)
        {
            return db.Chancelleries.Find(id);
        }

        public void Create(Chancellery chancellery, int authorId)
        {
            chancellery.s_EditorId = authorId;
            chancellery.s_EditDate = chancellery.s_DateCreation;
            chancellery.s_AuthorId = authorId;
            db.Chancelleries.Add(chancellery);
        }
        public void MoveToBasket(Chancellery chancellery, int EditorId)
        {
            chancellery.s_InBasket = true;
            Update(chancellery, EditorId);
        }
        public void Update(Chancellery chancellery, int authorId)
        {
            chancellery.s_EditorId = authorId;
            chancellery.s_EditDate = DateTime.Now;
            db.Entry(chancellery).State = EntityState.Modified;
        }

        public IEnumerable<Chancellery> Find(Func<Chancellery, Boolean> predicate)
        {
            return db.Chancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Chancellery book = db.Chancelleries.Find(id);
            if (book != null)
                db.Chancelleries.Remove(book);
        }
    }
}
