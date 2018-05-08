using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
    /// <summary>
    /// Абстрактный базовый класс репозитория
    /// </summary>
    public abstract class RepositoryBase
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