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
    class JournalRegistrationsChancelleryRepository : IRepository<JournalRegistrationsChancellery>
    {
        private ACSContext db;

        public JournalRegistrationsChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<JournalRegistrationsChancellery> GetAll()
        {
            return db.JournalRegistrationsChancelleries;
        }

        public JournalRegistrationsChancellery Get(int id)
        {
            return db.JournalRegistrationsChancelleries.Find(id);
        }


        public void Create(JournalRegistrationsChancellery journalRegistrationsChancellery, int authorId)
        {
            journalRegistrationsChancellery.s_EditorId = authorId;
            journalRegistrationsChancellery.s_EditDate = journalRegistrationsChancellery.s_DateCreation;
            journalRegistrationsChancellery.s_AuthorId = authorId;
            db.JournalRegistrationsChancelleries.Add(journalRegistrationsChancellery);
        }

        public void Update(JournalRegistrationsChancellery updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
        }

        public IEnumerable<JournalRegistrationsChancellery> Find(Func<JournalRegistrationsChancellery, Boolean> predicate)
        {
            return db.JournalRegistrationsChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            JournalRegistrationsChancellery Journal = db.JournalRegistrationsChancelleries.Find(id);
            if (Journal != null)
                db.JournalRegistrationsChancelleries.Remove(Journal);
        }

        public void MoveToBasket(JournalRegistrationsChancellery MoveObj, int EditorId)
        {
            throw new NotImplementedException();
        }
    }
}
