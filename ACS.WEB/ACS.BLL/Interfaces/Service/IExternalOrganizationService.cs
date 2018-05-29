using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IExternalOrganizationService : IDisposable
    {
        Task<int> CreateOrUpdateAsync(ExternalOrganizationDTO externalOrganizationDTO, string authorEmail);
        Task<int> DeleteAsync(int id);
        Task<ExternalOrganizationDTO> FindAsync(int id);
        Task<IEnumerable<ExternalOrganizationDTO>> GetAllAsync();
    }
}
