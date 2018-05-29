using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapDB
    {
        static DAL.Interfaces.IUnitOfWork db;

        public static void Init(DAL.Interfaces.IUnitOfWork uow)
        {
            db = uow;
            //MapDALBLL.Init(uow);
        }
        public static DAL.Interfaces.IUnitOfWork Db
        {
            get { return db; }
        }

    }
}
