using ACS.DAL.EF;
using ACS.DAL.Entity;
using ACS.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository
{
  public  class ProjectRegistryRepository : IRepository<ProjectRegistry>

    {
        private ACSContext db;

        public ProjectRegistryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProjectRegistry> GetAll()
        {
            return db.ProjectsRegistry;
        }

        public ProjectRegistry Get(int id)
        {
            return db.ProjectsRegistry.Find(id);
        }

        public void Create(ProjectRegistry user)
        {
            db.ProjectsRegistry.Add(user);
        }

        public void Update(ProjectRegistry ProjectRegistry)
        {
            db.Entry(ProjectRegistry).State = EntityState.Modified;
        }
  
        public void MoveToBasketEmployee(ProjectRegistry MoveObj, int EditorId)
        {
            MoveObj.s_InBasket = true;
            MoveObj.s_EditorId = EditorId;
            Update(MoveObj);
        }
        public IEnumerable<ProjectRegistry> Find(Func<ProjectRegistry, Boolean> predicate)
        {
            return db.ProjectsRegistry.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ProjectRegistry user = db.ProjectsRegistry.Find(id);
            if (user != null)
                db.ProjectsRegistry.Remove(user);
        }


    }
}