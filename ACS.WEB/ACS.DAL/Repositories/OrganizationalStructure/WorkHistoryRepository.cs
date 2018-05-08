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


        public void Create(WorkHistory workHistory, int authorId)
        {
            workHistory.s_EditorId = authorId;
            workHistory.s_EditDate = workHistory.s_DateCreation;
            workHistory.s_AuthorId = authorId;
            db.WorkHistories.Add(workHistory);
        }

        public void Update(WorkHistory updateObj, int editorId)
        {
            updateObj.s_EditorId = editorId;
            updateObj.s_EditDate = DateTime.Now;
            db.Entry(updateObj).State = EntityState.Modified;
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

        public void MoveToBasket(WorkHistory WorkHistory, int editorId)
        {
            WorkHistory.s_InBasket = true;
            Update(WorkHistory,editorId);
        }
    }
}
