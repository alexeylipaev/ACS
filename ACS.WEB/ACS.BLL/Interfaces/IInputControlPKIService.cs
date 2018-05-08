using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    interface IInputControlPKIService : IDisposable
    {
        Task<OperationDetails> CreatePKI(InputControlPKIDTO PKI, string authorEmail);
        Task<OperationDetails> UpdateAsync (InputControlPKIDTO PKI, string authorEmail);
        Task<OperationDetails> MoveToBaskePKIAsync(InputControlPKIDTO PKI, string authorEmail);
        Task<OperationDetails> DeleteAsync(int userId, string authorEmail);
        InputControlPKIDTO GetPKIAsync(int? id);
        IEnumerable<InputControlPKIDTO> GetAllPKI();
        /// <summary>
        /// Получить документы ПКИ
        /// </summary>
        /// <param name="PKI"></param>
        /// <returns></returns>
        IEnumerable<ReceivedDocPKIDTO> GetDocsPKI(InputControlPKIDTO PKI);

        Task<OperationDetails> AddDocAsync(InputControlPKIDTO PKI,IEnumerable<ReceivedDocPKIDTO> Docs);

        Task<OperationDetails> CheckOTKAsync(InputControlPKIDTO PKI);

        Task<OperationDetails> SentAsync(InputControlPKIDTO PKI);

        /// <summary>
        /// Получить ПКИ документа
        /// </summary>
        /// <param name="PKI"></param>
        /// <returns></returns>
        Task<InputControlPKIDTO> GetPKIDoc(ReceivedDocPKIDTO PKI);
    }
}
