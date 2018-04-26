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
    class FolderChancelleryRepository : IRepository<FolderChancellery>
    {
        private ACSContext db;

        public FolderChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<FolderChancellery> GetAll()
        {
            return db.FolderChancelleries;
        }

        public  FolderChancellery Get(int id)
        {
            return db.FolderChancelleries.Find(id);
        }
        public FolderChancellery Get(string propertyValue)
        {
            return db.FolderChancelleries.Find(propertyValue);
        }
        public FolderChancellery Get(Guid guid)
        {
            return db.FolderChancelleries.Find(guid);
        }

        public void Create(FolderChancellery  FolderChancellery)
        {
            db.FolderChancelleries.Add(FolderChancellery);
        }

        public void Update( FolderChancellery  FolderChancellery)
        {
            db.Entry( FolderChancellery).State = EntityState.Modified;
        }

        public IEnumerable<FolderChancellery> Find(Func<FolderChancellery, Boolean> predicate)
        {
            return db.FolderChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
             FolderChancellery folder = db.FolderChancelleries.Find(id);
            if (folder != null)
                db.FolderChancelleries.Remove(folder);
        }
    }
}
