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

        public ExternalOrganizationChancellery Get(Guid guid)
        {
            return db.ExternalOrganizationChancelleries.Find(guid);
        }

        public void Create(ExternalOrganizationChancellery ExternalOrganizationChancellery)
        {
            db.ExternalOrganizationChancelleries.Add(ExternalOrganizationChancellery);
        }

        public void Update(ExternalOrganizationChancellery ExternalOrganizationChancellery)
        {
            db.Entry(ExternalOrganizationChancellery).State = EntityState.Modified;
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
