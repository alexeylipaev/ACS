using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeePassportService : IDisposable
    {
        void CreateEmployeePassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail);

        void UpdateEmployeePassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail);

    
        EmployeePassportDTO GetEmployeePassport(int? id);
        EmployeeDTO GetUser(int? id);
        IEnumerable<EmployeePassportDTO> GetUsersPassport();

    }
}
