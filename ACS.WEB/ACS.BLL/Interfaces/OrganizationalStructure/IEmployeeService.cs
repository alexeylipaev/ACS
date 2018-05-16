using ACS.BLL.DTO;
using System;
using System.Collections.Generic;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        void CreateOrUpdateEmpl(EmployeeDTO userDto, string authorEmail);
        void MoveToBasketEmployee(int userId, string authorEmail);
        void DeleteEmployee(int userId );
        EmployeeDTO GetEmployee(int? id);

        IEnumerable<EmployeeDTO> GetEmployees();


    }
}
