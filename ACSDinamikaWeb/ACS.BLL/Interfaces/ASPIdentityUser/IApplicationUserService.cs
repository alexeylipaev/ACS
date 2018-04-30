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
    

        Task<OperationDetails> ResetPasswordAsync(ApplicationUserDTO applicationUserDTO);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);

        Task<OperationDetails> ConfirmEmailAsync(string userId, string token);

        Task SendEmailAsync(string userId, string subject, string body);

        Task<ClaimsIdentity> Authenticate(ApplicationUserDTO applicationUserDTO);

        Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles);

        Task<ApplicationUser> FindByNameAsync(string userName);

        Task<bool> IsEmailConfirmedAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(string userId);

        Task<OperationDetails> ResetPasswordAsync(string userId, string token, string newPassword);

        Task<OperationDetails> AddLoginAsync(string userId, UserLoginInfo login);

        Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login);

        Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO);

        IEnumerable<ApplicationUserDTO> GetUsers();
    }
}
