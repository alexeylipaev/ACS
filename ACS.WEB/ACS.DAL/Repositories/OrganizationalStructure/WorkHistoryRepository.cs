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
   public class WorkHistoryRepository : IRepository<WorkHistory>
    {
        private ACSContext db;

        public WorkHistoryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<WorkHistory> GetAll()
        {
            return db.WorkHistories;
        }

        public WorkHistory Get(int Id)
        {
            return db.WorkHistories.Find(Id);
        }


        public void Create(WorkHistory WorkHistory)
        {
            db.WorkHistories.Add(WorkHistory);
        }

        public void Update(WorkHistory WorkHistory)
        {
            db.Entry(WorkHistory).State = EntityState.Modified;
        }

        public IEnumerable<WorkHistory> Find(Func<WorkHistory, Boolean> predicate)
        {
            return db.WorkHistories.Where(predicate).ToList();
        }

        public void Delete(int Id)
        {
            WorkHistory WorkHistory = db.WorkHistories.Find(Id);
            if (WorkHistory != null)
                db.WorkHistories.Remove(WorkHistory);
        }
    }
}
