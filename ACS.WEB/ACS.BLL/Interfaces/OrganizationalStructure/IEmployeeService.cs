using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void CreateUser(EmployeeDTO userDto);

        void CreateUser(EmployeeDTO userDto, string authorEmail);

        void UpdateUser(EmployeeDTO userDto, string authorEmail);
        void MoveToBasketUser(int userId, string authorEmail);
        void DeleteUser(int userId, string authorEmail);
        EmployeeDTO GetUser(int? Id);

        IEnumerable<EmployeeDTO> GetUsers();

        void Dispose();
    }
}
