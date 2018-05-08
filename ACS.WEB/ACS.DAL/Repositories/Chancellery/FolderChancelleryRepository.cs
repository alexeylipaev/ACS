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


        public void Create(FolderChancellery  folderChancellery, int authorId)
        {
            folderChancellery.s_EditorId = authorId;
            folderChancellery.s_EditDate = folderChancellery.s_DateCreation;
            folderChancellery.s_AuthorId = authorId;
            db.FolderChancelleries.Add(folderChancellery);
        }

        public void Update( FolderChancellery  folderChancellery, int authorId)
        {
            folderChancellery.s_EditorId = authorId;
            folderChancellery.s_EditDate = DateTime.Now;
            db.Entry( folderChancellery).State = EntityState.Modified;
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

        public void MoveToBasket(FolderChancellery MoveObj, int EditorId)
        {
            MoveObj.s_InBasket = true;
            Update(MoveObj,EditorId);
        }
    }
}
