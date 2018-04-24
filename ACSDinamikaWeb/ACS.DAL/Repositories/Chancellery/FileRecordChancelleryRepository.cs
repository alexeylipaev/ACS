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

        public void Create(FileRecordChancellery FileRecordChancellery)
        {
            db.FileRecordChancelleries.Add(FileRecordChancellery);
        }

        public void Update(FileRecordChancellery FileRecordChancellery)
        {
            db.Entry(FileRecordChancellery).State = EntityState.Modified;
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
    }
}
