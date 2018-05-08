using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IProjectRegistryService : IDisposable
    {
        Task<OperationDetails> CreateAsync(ProjectRegistryDTO ProjectRegistry, string authorEmail);
        Task<OperationDetails> UpdateAsync(ProjectRegistryDTO ProjectRegistry, string authorEmail);
        Task<OperationDetails> MoveToBaskeProjectRegistryAsync(ProjectRegistryDTO ProjectRegistry, string authorEmail);
        Task<OperationDetails> DeleteAsync(int userId, string authorEmail);
        ProjectRegistryDTO GetProjectRegistryAsync(int? id);
        IEnumerable<ProjectRegistryDTO> GetProjectsRegistry();

        /// <summary>
        /// Получить ПКИ по проекту
        /// </summary>
        /// <param name="ProjectRegistry"></param>
        /// <returns></returns>
        IEnumerable<InputControlPKIDTO> GetPKIProjectRegistry(ProjectRegistryDTO ProjectRegistry);

     
        /// <summary>
        /// Получить Документы ПКИ
        /// </summary>
        /// <param name="ProjectRegistry"></param>
        /// <returns></returns>
        Task<ReceivedDocPKIDTO> GetDocsPKIProjectRegistry(InputControlPKIDTO PKIProject);
    }
}
