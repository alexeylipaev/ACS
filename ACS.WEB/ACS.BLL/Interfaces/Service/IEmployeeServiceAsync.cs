using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task<int> CreateOrUpdateAsync(EmployeeDTO EmplDto, string authorEmail);
        Task<int> DeleteAsync(int id);
        Task<EmployeeDTO> FindAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<IEnumerable<EmployeeDTO>> GetAllResponsiblesChancelleryAsync(CorrespondencesBaseDTO correspondencesDTO);
    }
}
