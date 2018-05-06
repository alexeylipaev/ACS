﻿using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
    public class AccountAppUserService : IAccountAppUserService
    {
        IUnitOfWork Database { get; set; }          public AccountAppUserService(IUnitOfWork uow)         {             Database = uow;         }

        public async Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login)         {             var result = await Database.UserManager.AddLoginAsync(userId, login);              if (result.Errors.Count() > 0)                 return new OperationDetails(false, result.Errors.FirstOrDefault(), "");              return new OperationDetails(true, result.Errors.FirstOrDefault(), "");         }

        public async Task<ClaimsIdentity> Authenticate(ApplicationUserDTO ApplicationUserDTO)         {             ClaimsIdentity claim = null;             // находим пользователя             ApplicationUser user = await Database.UserManager.FindAsync(ApplicationUserDTO.Email, ApplicationUserDTO.PasswordHash);             // авторизуем его и возвращаем объект ClaimsIdentity             if (user != null)                 claim = await Database.UserManager.CreateIdentityAsync(user,                                             DefaultAuthenticationTypes.ApplicationCookie);             return claim;         }

        public async Task<OperationDetails> ConfirmEmailAsync(int UserId, string token)         {              var result = await Database.UserManager.ConfirmEmailAsync(UserId, token);             if (result.Errors.Count() > 0)                 return new OperationDetails(false, result.Errors.FirstOrDefault(), "Ошибка подтверждения");             else                 return new OperationDetails(true, "Регистрация успешно подтверждена", "");         }

 public async Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO)         {              ApplicationUser appUser = await Database.UserManager.FindByEmailAsync(applicationUserDTO.Email);              if (appUser == null)             {                 var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO ,ApplicationUser>()).CreateMapper();                  appUser = mapper.Map<ApplicationUserDTO , ApplicationUser>(applicationUserDTO);                  var result = await Database.UserManager.CreateAsync(appUser, applicationUserDTO.PasswordHash);                  //// создаем профиль клиента                 //Employee empl = new Employee {id = appUser.id, Email = appUser.Email};                  //appUser.Employee = empl;                  if (result.Errors.Count() > 0)                     return new OperationDetails(false, result.Errors.FirstOrDefault(), "");                  if (applicationUserDTO.Roles != null && applicationUserDTO.Roles.Any(r=>r != null) )                 {                     foreach (var role in applicationUserDTO.Roles)                     {                         var r = await Database.RoleManager.FindByIdAsync(role.RoleId);                         if(r != null)                         await Database.UserManager.AddToRolesAsync(appUser.Id, r.Name);                     }                  }                 else                 {                     var r = await Database.RoleManager.FindByIdAsync(1);                     await Database.UserManager.AddToRoleAsync(appUser.Id, r.Name);                 }                  await Database.SaveAsync();                  return new OperationDetails(true, "Пользователь успешно создан", "");             }             else             {                 return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");             }         }

        public ApplicationUserDTO FindByEmail(string Email)         {             if (string.IsNullOrEmpty(Email))                 throw new ValidationException("Почта пользователя не установлена", "");              var appUser = (from user in Database.UserManager.Users                            where user.Email == Email                            select user).FirstOrDefault();              if (appUser == null)                 throw new ValidationException("Пользователь не найден", "");              var mapper = new MapperConfiguration(cfg =>
            {                 cfg.CreateMap<AppUserRole, int>().ConvertUsing(source => source.RoleId);

                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()/*.ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles))*/;              }             ).CreateMapper();              var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);             return result;         }

 public async Task<ApplicationUserDTO> FindByEmailAsync(string Email)         {             if (string.IsNullOrEmpty(Email))                 throw new ValidationException("Почта пользователя не установлена", "");              var appUser = await Database.UserManager.FindByEmailAsync(Email);             if (appUser == null)                 throw new ValidationException("Пользователь не найден", "");              var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();              var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);             return result;         }

        public async Task<ApplicationUserDTO> FindByNameAsync(string userName)         {             if (string.IsNullOrEmpty(userName))                 throw new ValidationException("Имя пользователя не установлено", "");              var appUser = await Database.UserManager.FindByNameAsync(userName);             if (appUser == null)                 throw new ValidationException("Пользователь не найден", "");              var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();              var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);             return result;         }

        public ApplicationRoleDTO FindRoleById(int roleId)         {             if (roleId == default(int))                 throw new ValidationException("Роль  не установлена", "");              var AppRole = (from role in Database.RoleManager.Roles.ToList()                            where role.Id == roleId                            select role).FirstOrDefault();              if (AppRole == null)                 throw new ValidationException("Роль не найдена", "");              var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();              var result = mapper.Map<ApplicationRole, ApplicationRoleDTO>(AppRole);             return result;         }

        public async Task<string> GenerateEmailConfirmationTokenAsync(int userId)         {             string code = await Database.UserManager.GenerateEmailConfirmationTokenAsync(userId);              return code;         }

        public async Task<string> GeneratePasswordResetTokenAsync(int userId)         {             var data = await Database.UserManager.GeneratePasswordResetTokenAsync(userId);              return data;         }

        /// <summary>         /// Назначить роль         /// </summary>         /// <param name="RoleId"></param>         /// <param name="UserId">Null если нужно создать роль для нового пользователя, not null если пользователь уже есть в БД, поместить его ID</param>         /// <returns></returns>         public AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null)         {             AppUserRoleDTO result = null;             try             {
                UserId = UserId ?? GetIdNewAppUser();
                result = new AppUserRoleDTO() { RoleId = RoleId, UserId = (int)UserId };             }             catch (Exception e)             {

                Debug.WriteLine("Имя члена:               {0}", e.TargetSite);
                Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
                Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
                Debug.WriteLine("Message:                 {0}", e.Message);
                Debug.WriteLine("Source:                  {0}", e.Source);
                Debug.WriteLine("Help Link:               {0}", e.HelpLink);
                Debug.WriteLine("Stack:                   {0}", e.StackTrace);                  foreach (DictionaryEntry de in e.Data)                     Debug.WriteLine("{0} : {1}", de.Key, de.Value);             }

            return result;         }

        /// <summary>     /// Получить ID нового объекта     /// </summary>     /// <returns></returns>         public int GetIdNewAppUser()         {
            return Database.UserManager.Users.ToList().Max(appUser => appUser.Id) + 1;         }

        public async Task<bool> IsEmailConfirmedAsync(int userId)         {             var data = await Database.UserManager.IsEmailConfirmedAsync(userId);              return data;         }

        public bool IsInRole(string userName, string role)         {             bool result = false;             var applicationUser = Database.UserManager.FindByName(userName);              if (applicationUser != null)             {                 var AppRole = Database.RoleManager.FindByName(role);                 if (AppRole != null)                     return AppRole.Users.Any(u => u.UserId == applicationUser.Id);             }             return result;         }

        public async Task<OperationDetails> ResetPasswordAsync(int userId, string token, string newPassword)         {             var result = await Database.UserManager.ResetPasswordAsync(userId, token, newPassword);              if (result.Errors.Count() > 0)                 return new OperationDetails(false, result.Errors.FirstOrDefault(), "Ошибка сброса пароля");             else                 return new OperationDetails(true, "Пароль успешно сброшен", "");         }

        public async Task SendEmailAsync(int userId, string subject, string body)         {             await Database.UserManager.SendEmailAsync(userId, subject, body);         }

        // начальная инициализация бд
        public async Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles)         {             foreach (string roleName in roles)             {                 var role = await Database.RoleManager.FindByNameAsync(roleName);                 if (role == null)                 {                     role = new ApplicationRole { Name = roleName };                     await Database.RoleManager.CreateAsync(role);                 }             }              var appUser = await Database.UserManager.FindByEmailAsync(adminDto.Email);              if (appUser == null)                 await CreateAsync(adminDto);         }
        public void Dispose()         {             Database.Dispose();         }
    }
}