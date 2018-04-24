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
        void MakeUserPassport(UserPassportDTO UserPassportDTO);
        UserPassportDTO GetUserPassport(int? id);
        IEnumerable<UserPassportDTO> GetUserPassport();
        void Dispose();
    }
}
