using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.EF
{
    public class MyContextFactory : IDbContextFactory<ACSContext>
    {
        public ACSContext Create()
        {
            return new ACSContext();
        }
    }
}
