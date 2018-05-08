using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;
using ACS.BLL.DTO;

namespace ACS.BLL.Services.InputControlPKI
{
    public class InputControlPKIService: IInputControlPKIService
    {
        IUnitOfWork Database { get; set; }

        public InputControlPKIService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Task<OperationDetails> CreatePKI(InputControlPKIDTO PKI, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> UpdateAsync(InputControlPKIDTO PKI, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> MoveToBaskePKIAsync(InputControlPKIDTO PKI, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> DeleteAsync(int userId, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public InputControlPKIDTO GetPKIAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InputControlPKIDTO> GetAllPKI()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReceivedDocPKIDTO> GetDocsPKI(InputControlPKIDTO PKI)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> AddDocAsync(InputControlPKIDTO PKI, IEnumerable<ReceivedDocPKIDTO> Docs)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> CheckOTKAsync(InputControlPKIDTO PKI)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> SentAsync(InputControlPKIDTO PKI)
        {
            throw new NotImplementedException();
        }

        public Task<InputControlPKIDTO> GetPKIDoc(ReceivedDocPKIDTO PKI)
        {
            throw new NotImplementedException();
        }
    }
}
