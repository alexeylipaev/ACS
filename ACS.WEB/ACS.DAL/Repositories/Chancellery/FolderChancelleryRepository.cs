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

        public  FolderChancellery Get(int Id)
        {
            return db.FolderChancelleries.Find(Id);
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

        public void Delete(int Id)
        {
             FolderChancellery folder = db.FolderChancelleries.Find(Id);
            if (folder != null)
                db.FolderChancelleries.Remove(folder);
        }
    }
}
