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
    //public class ApplicationLoginRepository : IRepository<ApplicationLogin>

    //{
    //    private ACSContext db;

    //    public ApplicationLoginRepository(ACSContext context)
    //    {
    //        this.db = context;
    //    }

    //    public IEnumerable<ApplicationLogin> GetAll()
    //    {
    //        return db.ApplicationLogins;
    //    }

    //    public ApplicationLogin Get(int Id)
    //    {
    //        return db.ApplicationLogins.Find(Id);
    //    }



    //    public void Create(ApplicationLogin ApplicationLogin)
    //    {
    //        db.ApplicationLogins.Add(ApplicationLogin);
    //    }

    //    public void Update(ApplicationLogin ApplicationLogin)
    //    {
    //        db.Entry(ApplicationLogin).State = EntityState.Modified;
    //    }

    //    public IEnumerable<ApplicationLogin> Find(Func<ApplicationLogin, Boolean> predicate)
    //    {
    //        return db.ApplicationLogins.Where(predicate).ToList();
    //    }

    //    public void Delete(int Id)
    //    {
    //        ApplicationLogin Login = db.ApplicationLogins.Find(Id);
    //        if (Login != null)
    //            db.ApplicationLogins.Remove(Login);
    //    }
    //}
}
