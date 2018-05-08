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
    public class ExternalOrganizationChancelleryRepository : IRepository<ExternalOrganizationChancellery>
    {
        private ACSContext db;

        public ExternalOrganizationChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ExternalOrganizationChancellery> GetAll()
        {
            return db.ExternalOrganizationChancelleries;
        }

        public ExternalOrganizationChancellery Get(int id)
        {
            return db.ExternalOrganizationChancelleries.Find(id);
        }


        public void Create(ExternalOrganizationChancellery externalOrganizationChancellery, int authorId)
        {
            externalOrganizationChancellery.s_EditorId = authorId;
            externalOrganizationChancellery.s_EditDate = externalOrganizationChancellery.s_DateCreation;
            externalOrganizationChancellery.s_AuthorId = authorId;
            db.ExternalOrganizationChancelleries.Add(externalOrganizationChancellery);
        }
        public void MoveToBasket(ExternalOrganizationChancellery ExternalOrganizationChancellery, int EditorId)
        {
            ExternalOrganizationChancellery.s_InBasket = true;
            Update(ExternalOrganizationChancellery, EditorId);
        }
        public void Update(ExternalOrganizationChancellery externalOrganizationChancellery, int authorId)
        {
            externalOrganizationChancellery.s_EditorId = authorId;
            externalOrganizationChancellery.s_EditDate = DateTime.Now;
            db.Entry(externalOrganizationChancellery).State = EntityState.Modified;
        }

        public IEnumerable<ExternalOrganizationChancellery> Find(Func<ExternalOrganizationChancellery, Boolean> predicate)
        {
            return db.ExternalOrganizationChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ExternalOrganizationChancellery book = db.ExternalOrganizationChancelleries.Find(id);
            if (book != null)
                db.ExternalOrganizationChancelleries.Remove(book);
        }
    }
}
