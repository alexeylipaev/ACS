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
    public class FileRecordChancelleryRepository : IRepository<FileRecordChancellery>
    {
        private ACSContext db;

        public FileRecordChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<FileRecordChancellery> GetAll()
        {
            return db.FileRecordChancelleries;
        }

        public FileRecordChancellery Get(int id)
        {
            return db.FileRecordChancelleries.Find(id);
        }


        public void Create(FileRecordChancellery fileRecordChancellery, int authorId)
        {
            fileRecordChancellery.s_EditorId = authorId;
            fileRecordChancellery.s_EditDate = fileRecordChancellery.s_DateCreation;
            fileRecordChancellery.s_AuthorId = authorId;
            db.FileRecordChancelleries.Add(fileRecordChancellery);
        }

        public void Update(FileRecordChancellery fileRecordChancellery, int authorId)
        {
            fileRecordChancellery.s_EditorId = authorId;
            fileRecordChancellery.s_EditDate = DateTime.Now;
            db.Entry(fileRecordChancellery).State = EntityState.Modified;
        }

        public IEnumerable<FileRecordChancellery> Find(Func<FileRecordChancellery, Boolean> predicate)
        {
            return db.FileRecordChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            FileRecordChancellery FileRecord = db.FileRecordChancelleries.Find(id);
            if (FileRecord != null)
                db.FileRecordChancelleries.Remove(FileRecord);
        }

        public void MoveToBasket(FileRecordChancellery MoveObj, int EditorId)
        {
            MoveObj.s_InBasket = true;
            Update(MoveObj, EditorId);
        }
    }
}
