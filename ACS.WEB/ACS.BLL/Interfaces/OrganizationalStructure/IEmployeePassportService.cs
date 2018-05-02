using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeePassportService
    {
        void MakeUserPassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail);

        void UpdateUserPassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail);

    
        EmployeePassportDTO GetUserPassport(int? Id);
        EmployeeDTO GetUser(int? Id);
        IEnumerable<EmployeePassportDTO> GetUsersPassport();
        void Dispose();
    }
}
