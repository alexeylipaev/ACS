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
    class ToChancelleryRepository : IRepository<ToChancellery>
    {
        private ACSContext db;

        public ToChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ToChancellery> GetAll()
        {
            return db.ToChancelleries;
        }

        public ToChancellery Get(int id)
        {
            return db.ToChancelleries.Find(id);
        }
        public void MoveToBasket(ToChancellery ToChancellery, int editorId)
        {
            ToChancellery.s_InBasket = true;
            Update(ToChancellery, editorId);
        }

        public void Create(ToChancellery toChancellery, int authorId)
        {
            toChancellery.s_EditorId = authorId;
            toChancellery.s_EditDate = toChancellery.s_DateCreation;
            toChancellery.s_AuthorId = authorId;
            db.ToChancelleries.Add(toChancellery);
        }

        public void Update(ToChancellery updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
        }

        public IEnumerable<ToChancellery> Find(Func<ToChancellery, Boolean> predicate)
        {
            return db.ToChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ToChancellery to = db.ToChancelleries.Find(id);
            if (to != null)
                db.ToChancelleries.Remove(to);
        }
    }
}
