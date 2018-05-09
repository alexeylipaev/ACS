using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface ISystemParametersService : IDisposable
    {
        void CreateSystemParameters(SystemParametersDTO SystemParametersDTO);
        SystemParametersDTO GetSystemParameters(int? id);
        IEnumerable<SystemParametersDTO> GetSystemParameters();
  
    }
}
