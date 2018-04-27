using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IUserPassportService
    {
        void MakeUserPassport(UserPassportDTO UserPassportDTO, string authorEmail);

        void UpdateUserPassport(UserPassportDTO UserPassportDTO, string authorEmail);

    
        UserPassportDTO GetUserPassport(int? Id);
        UserDTO GetUser(int? Id);
        IEnumerable<UserPassportDTO> GetUsersPassport();
        void Dispose();
    }
}
