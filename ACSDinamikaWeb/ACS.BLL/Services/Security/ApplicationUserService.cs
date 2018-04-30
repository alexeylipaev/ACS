using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using ACS.BLL.BusinessModels;
using AutoMapper;


namespace ACS.BLL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        IUnitOfWork Database { get; set; }

        public ApplicationUserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(ApplicationUserDTO applicationUserDTO)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(applicationUserDTO.Email);

            if (user == null)
            {
                user = new ApplicationUser { Email = applicationUserDTO.Email, UserName = applicationUserDTO.UserName };

                var result = await Database.UserManager.CreateAsync(user, applicationUserDTO.PasswordHash);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем роль
                foreach (var roleId in applicationUserDTO.RolesID)
                {
                    var roleName = Database.RoleManager.FindById(roleId.ToString()).Name;
                    await Database.UserManager.AddToRoleAsync(user.Id, roleName);
                }

                // создаем профиль клиента
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUser>()).CreateMapper();
                ApplicationUser applicationUser = mapper.Map<ApplicationUserDTO, ApplicationUser>(applicationUserDTO);

                //User.s_AuthorID = author.Id;
                //User.s_EditorID = author.Id;

                Database.UserManager.Create(applicationUser);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }


        // начальная инициализация бд
        public async Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
        public IEnumerable<ApplicationUserDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<ClaimsIdentity> Authenticate(ApplicationUserDTO ApplicationUserDTO)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(ApplicationUserDTO.Email, ApplicationUserDTO.PasswordHash);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }



        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> ResetPasswordAsync(ApplicationUserDTO applicationUserDTO)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(applicationUserDTO.Email);

            if (user == null)
            {
                user = new ApplicationUser { Email = applicationUserDTO.Email, UserName = applicationUserDTO.UserName };

                var result = await Database.UserManager.CreateAsync(user, applicationUserDTO.PasswordHash);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем роль
                foreach (var roleId in applicationUserDTO.RolesID)
                {
                    var roleName = Database.RoleManager.FindById(roleId.ToString()).Name;
                    await Database.UserManager.AddToRoleAsync(user.Id, roleName);
                }

                // создаем профиль клиента
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUser>()).CreateMapper();
                ApplicationUser applicationUser = mapper.Map<ApplicationUserDTO, ApplicationUser>(applicationUserDTO);

                //User.s_AuthorID = author.Id;
                //User.s_EditorID = author.Id;

                Database.UserManager.Create(applicationUser);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<OperationDetails> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            var result = await Database.UserManager.ResetPasswordAsync(userId, token, newPassword);

            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

            return new OperationDetails(true, result.Errors.FirstOrDefault(), "");
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            string code = await Database.UserManager.GenerateEmailConfirmationTokenAsync(userId);

            return code;
        }

        public async Task<OperationDetails> ConfirmEmailAsync(string UserId, string token)
        {

            var result = await Database.UserManager.ConfirmEmailAsync(UserId, token);
            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "Ошибка подтверждения");
            else
                return new OperationDetails(true, "Регистрация успешно подтверждена", "");
        }

        public async Task SendEmailAsync(string userId, string subject, string body)
        {
            await Database.UserManager.SendEmailAsync(userId, subject, body);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var data = await Database.UserManager.FindByNameAsync(userName);

            return data;
        }
        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var data = await Database.UserManager.IsEmailConfirmedAsync(userId);

            return data;
        }
        public async Task<string> GeneratePasswordResetTokenAsync(string userId)
        {
            var data = await Database.UserManager.GeneratePasswordResetTokenAsync(userId);

            return data;
        }
        public async Task<OperationDetails> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await Database.UserManager.AddLoginAsync(userId, login);

            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

            return new OperationDetails(true, result.Errors.FirstOrDefault(), "");
        }
        public async Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login)
        {
            return await AddLoginAsync(userId.ToString(), login);
        }

        public async Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO)
        {
            ApplicationUser applicationUser= new ApplicationUser
            {
                Email = applicationUserDTO.Email,
                PasswordHash = applicationUserDTO.PasswordHash,
                UserName = applicationUserDTO.UserName,
              
                //Address = model.Address,
                //Name = model.Name,
          
            };

            // добавляем роль
            foreach (var roleId in applicationUserDTO.RolesID)
            {
                var roleName = Database.RoleManager.FindById(roleId.ToString()).Name;
                await Database.UserManager.AddToRoleAsync(applicationUserDTO.Id.ToString(), roleName);
            }

            var result = await Database.UserManager.CreateAsync(applicationUser);

            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

            return new OperationDetails(true, "Пользователь успешно создан", "");



        }
    }
}