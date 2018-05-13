using ACS.BLL.DTO;
using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IMapper_DB_DTO_EmplService
    {
        Employee Map_EmployeeDTO_to_Employee(EmployeeDTO EmployeeDTO);

        EmployeeDTO Map_Employee_to_EmployeeDTO(Employee Employee);

        IEnumerable<EmployeeDTO> MappListEmplsToListEmplsDTO(IEnumerable<Employee> Empls);

        IEnumerable<Employee> MappListEmplsDTOToListEmpls(IEnumerable<EmployeeDTO> EmplsDTO);

    }
}
