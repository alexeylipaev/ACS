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
    public class FromChancelleryRepository : IRepository<FromChancellery>
    {
        private ACSContext db;

        public FromChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<FromChancellery> GetAll()
        {
            return db.FromChancelleries;
        }

        public FromChancellery Get(int id)
        {
            return db.FromChancelleries.Find(id);
        }


        public void Create(FromChancellery fromChancellery, int authorId)
        {
            fromChancellery.s_EditorId = authorId;
            fromChancellery.s_EditDate = fromChancellery.s_DateCreation;
            fromChancellery.s_AuthorId = authorId;
            db.FromChancelleries.Add(fromChancellery);
        }

        public void Update(FromChancellery updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
        }

        public IEnumerable<FromChancellery> Find(Func<FromChancellery, Boolean> predicate)
        {
            return db.FromChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            FromChancellery From = db.FromChancelleries.Find(id);
            if (From != null)
                db.FromChancelleries.Remove(From);
        }

        public void MoveToBasket(FromChancellery MoveObj, int editorId)
        {
            MoveObj.s_InBasket = true;
            Update(MoveObj, editorId);
        }
    }
}
