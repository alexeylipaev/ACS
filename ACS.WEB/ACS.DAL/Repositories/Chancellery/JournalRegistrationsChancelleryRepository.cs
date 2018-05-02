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

        public JournalRegistrationsChancellery Get(int Id)
        {
            return db.JournalRegistrationsChancelleries.Find(Id);
        }


        public void Create(JournalRegistrationsChancellery JournalRegistrationsChancellery)
        {
            db.JournalRegistrationsChancelleries.Add(JournalRegistrationsChancellery);
        }

        public void Update(JournalRegistrationsChancellery JournalRegistrationsChancellery)
        {
            db.Entry(JournalRegistrationsChancellery).State = EntityState.Modified;
        }

        public IEnumerable<JournalRegistrationsChancellery> Find(Func<JournalRegistrationsChancellery, Boolean> predicate)
        {
            return db.JournalRegistrationsChancelleries.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            JournalRegistrationsChancellery Journal = db.JournalRegistrationsChancelleries.Find(Id);
            if (Journal != null)
                db.JournalRegistrationsChancelleries.Remove(Journal);
        }
    }
}
