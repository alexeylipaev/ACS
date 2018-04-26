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
        void MakeUser(UserDTO userDto);

        void MakeUser(UserDTO userDto, string authorEmail);

        void UpdateUser(UserDTO userDto, string authorEmail);

        UserDTO GetUser(int? id);

        IEnumerable<UserDTO> GetUsers();

        void Dispose();
    }
}
