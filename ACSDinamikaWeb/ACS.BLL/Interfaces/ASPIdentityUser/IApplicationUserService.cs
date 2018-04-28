using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IApplicationUserService
    {

        //ApplicationUserDTO GetApplicationUser(int? Id);
        //IEnumerable<ApplicationUserDTO> GetApplicationUser();

        Task<OperationDetails> Create(ApplicationUserDTO applicationUserDTO);
        Task<ClaimsIdentity> Authenticate(ApplicationUserDTO applicationUserDTO);
        Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles);

        void Dispose();
        IEnumerable<ApplicationUserDTO> GetUsers();
    }
}
