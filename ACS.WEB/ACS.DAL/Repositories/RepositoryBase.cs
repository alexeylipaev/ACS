using ACS.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
  public abstract  class RepositoryBase
    {
        private ACSContext db;

        public RepositoryBase(ACSContext context)
        {
            this.db = context;
        }

        protected virtual ACSContext DbContext
        {
            get { return db; }
        }
    }
}
