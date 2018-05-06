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

        public WorkHistory Get(int id)
        {
            return db.WorkHistories.Find(id);
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

        public void Delete(int id)
        {
            WorkHistory WorkHistory = db.WorkHistories.Find(id);
            if (WorkHistory != null)
                db.WorkHistories.Remove(WorkHistory);
        }

        public void MoveToBasketEmployee(WorkHistory WorkHistory, int EditorId)
        {
            WorkHistory.s_InBasket = true;
            WorkHistory.s_EditorId = EditorId;
            Update(WorkHistory);
        }
    }
}
