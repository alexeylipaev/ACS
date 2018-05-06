using ACS.BLL.DTO;
using System;
using System.Collections.Generic;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        void CreateEmployee(EmployeeDTO userDto);
        void CreateEmployee(EmployeeDTO userDto, string authorEmail);
        void UpdateEmployee(EmployeeDTO userDto, string authorEmail);
        void MoveToBasketEmployee(int userId, string authorEmail);
        void DeleteEmployee(int userId, string authorEmail);
        EmployeeDTO GetEmployee(int? id);

        IEnumerable<EmployeeDTO> GetEmployees();


    }
}
