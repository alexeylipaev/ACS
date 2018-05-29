using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
  public interface  ITypeRecordChancelleryService : IDisposable
    {
        Task<int> CreateOrUpdateAsync(TypeRecordCorrespondencesDTO typeDTO, string authorEmail);

        Task<TypeRecordCorrespondencesDTO> FindAsync(int id);
        Task<IEnumerable<TypeRecordCorrespondencesDTO>> GetAllAsync();
        Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleriesByTypeAsync(int typeId);
        Task<int> DeleteAsync(int id);
        
    }
}
