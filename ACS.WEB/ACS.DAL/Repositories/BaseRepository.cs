using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
    class BaseRepository// : IRepository<SystemParameters>
    {
        public virtual void Create(SystemParameters item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemParameters> Find(Func<SystemParameters, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public SystemParameters Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemParameters> GetAll()
        {
            throw new NotImplementedException();
        }

        public void MoveToBasket(SystemParameters MoveObj, int EditorId)
        {
            throw new NotImplementedException();
        }

        public void Update(SystemParameters MoveObj, int EditorId)
        {
            throw new NotImplementedException();
        }
    }
}
