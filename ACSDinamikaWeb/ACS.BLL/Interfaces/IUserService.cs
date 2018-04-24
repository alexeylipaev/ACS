using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IUserService
    {
        void MakeOrder(UserDTO orderDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
