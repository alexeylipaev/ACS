using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void MakeUser(EmployeeDTO userDto);

        void MakeUser(EmployeeDTO userDto, string authorEmail);

        void UpdateUser(EmployeeDTO userDto, string authorEmail);

        EmployeeDTO GetUser(int? Id);

        IEnumerable<EmployeeDTO> GetUsers();

        void Dispose();
    }
}
