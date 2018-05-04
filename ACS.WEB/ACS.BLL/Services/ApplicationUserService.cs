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
            await CreateAsync(adminDto);
        }


        public async Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO)
        {

            ApplicationUser appUser = await Database.UserManager.FindByEmailAsync(applicationUserDTO.Email);

            if (appUser == null)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO ,ApplicationUser>()).CreateMapper();
                 appUser = mapper.Map<ApplicationUserDTO , ApplicationUser>(applicationUserDTO);

                var result = await Database.UserManager.CreateAsync(appUser, applicationUserDTO.PasswordHash);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем роль
                foreach (var roleId in applicationUserDTO.RolesId)
                {
                    var roleName = Database.RoleManager.FindById(roleId).Name;
                    await Database.UserManager.AddToRoleAsync(appUser.Id, roleName);
                }

                // создаем профиль клиента
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUser>()).CreateMapper();
                ApplicationUser applicationUser = mapper.Map<ApplicationUserDTO, ApplicationUser>(applicationUserDTO);

                //User.s_AuthorID = author.Id;
                //User.s_EditorID = author.Id;

                Database.UserManager.Create(applicationUser);
                await Database.SaveAsync();

                return new OperationDetails(true, "Пользователь успешно создан", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }




        public IEnumerable<ApplicationUserDTO> GetApplicationUsers()
        {
            var users = Database.UserManager.Users;
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, List<ApplicationUserDTO>>(users.ToList());
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



        public async Task<OperationDetails> ResetPasswordAsync(int userId, string token, string newPassword)
        {
            var result = await Database.UserManager.ResetPasswordAsync(userId, token, newPassword);

            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "Ошибка сброса пароля");
            else
                return new OperationDetails(true, "Пароль успешно сброшен", "");
        }


        public async Task<string> GenerateEmailConfirmationTokenAsync(int userId)
        {
            string code = await Database.UserManager.GenerateEmailConfirmationTokenAsync(userId);

            return code;
        }

        public async Task<OperationDetails> ConfirmEmailAsync(int UserId, string token)
        {

            var result = await Database.UserManager.ConfirmEmailAsync(UserId, token);
            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "Ошибка подтверждения");
            else
                return new OperationDetails(true, "Регистрация успешно подтверждена", "");
        }

        public async Task SendEmailAsync(int userId, string subject, string body)
        {
            await Database.UserManager.SendEmailAsync(userId, subject, body);
        }


        public bool IsInRole(string userName, string role)
        {
            bool result = false;
            var applicationUser = Database.UserManager.FindByName(userName);

            if (applicationUser != null)
            {
                var AppRole = Database.RoleManager.FindByName(role);
                if (AppRole != null)
                    return AppRole.Users.Any(u => u.UserId == applicationUser.Id);
            }
            return result;
        }

        public async Task<ApplicationUserDTO> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ValidationException("Имя пользователя не установлено", "");

            var appUser = await Database.UserManager.FindByNameAsync(userName);
            if (appUser == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();

            var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);
            return result;
        }
        public async Task<ApplicationUserDTO> FindByEmailAsync(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                throw new ValidationException("Почта пользователя не установлена", "");

            var appUser = await Database.UserManager.FindByEmailAsync(Email);
            if (appUser == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();

            var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);
            return result;
        }

        public ApplicationUserDTO FindByEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                throw new ValidationException("Почта пользователя не установлена", "");

            var appUser = (from user in Database.UserManager.Users
                           where !string.IsNullOrWhiteSpace(user.Email) 
                           where user.Email == Email
                           select user).FirstOrDefault();

            if (appUser == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<AppUserRole, int>().ConvertUsing(source => source.RoleId);
                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().ForMember(dest => dest.RolesId, opts => opts.MapFrom(src => src.Roles));
                
          }
            ).CreateMapper();

            var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);
            return result;
        }

        public async Task<bool> IsEmailConfirmedAsync(int userId)
        {
            var data = await Database.UserManager.IsEmailConfirmedAsync(userId);

            return data;
        }


        public async Task<string> GeneratePasswordResetTokenAsync(int userId)
        {
            var data = await Database.UserManager.GeneratePasswordResetTokenAsync(userId);

            return data;
        }


        public async Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login)
        {
            var result = await Database.UserManager.AddLoginAsync(userId, login);

            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

            return new OperationDetails(true, result.Errors.FirstOrDefault(), "");
        }

        public ApplicationRoleDTO FindRoleById(int roleId)
        {
            if (roleId == default(int))
                throw new ValidationException("Роль  не установлена", "");

            var AppRole = (from role in Database.RoleManager.Roles.ToList()
                           where role.Id == roleId
                           select role).FirstOrDefault();

            if (AppRole == null)
                throw new ValidationException("Роль не найдена", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();

            var result = mapper.Map<ApplicationRole, ApplicationRoleDTO>(AppRole);
            return result;



        }

        public void Dispose()
        {
            Database.Dispose();
        }

      
    }
}