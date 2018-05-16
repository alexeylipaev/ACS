using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;

namespace ACS.WEB.Tests.Controllers.TetServices
{
    class EmployeeServiceTest : IEmployeeService
    {
     
        public void DeleteEmployee(int userId, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO GetEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void MoveToBasketEmployee(int userId, string authorEmail)
        {
            throw new NotImplementedException();
        }

   

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EmployeeServiceTest() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public void DeleteEmployee(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateEmpl(EmployeeDTO userDto, string authorEmail)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
