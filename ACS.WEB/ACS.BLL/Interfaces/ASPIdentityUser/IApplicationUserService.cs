using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{

    public interface IApplicationUserService : IDisposable
    {

        //ApplicationUserDTO GetApplicationUser(int? Id);
        //IEnumerable<ApplicationUserDTO> GetApplicationUser();

        
        Task<OperationDetails> ResetPasswordAsync(int userId, string token, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(int userId);

        Task<OperationDetails> ConfirmEmailAsync(int userId, string token);

        Task SendEmailAsync(int userId, string subject, string body);


        Task<ClaimsIdentity> Authenticate(ApplicationUserDTO applicationUserDTO);

        Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles);

        Task<ApplicationUserDTO> FindByNameAsync(string userName);
   
        Task<ApplicationUserDTO> FindByEmailAsync(string Email);

        ApplicationUserDTO FindByEmail(string Email);

        ApplicationRoleDTO FindRoleById(int roleId);

        Task<bool> IsEmailConfirmedAsync(int userId);

        bool IsInRole(string userName, string role);

        Task<string> GeneratePasswordResetTokenAsync(int userId);

        Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login);

        Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO);

        IEnumerable<ApplicationUserDTO> GetApplicationUsers();
    }
}
