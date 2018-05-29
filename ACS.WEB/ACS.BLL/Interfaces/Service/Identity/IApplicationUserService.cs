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

    public interface IApplicationUserService : IApplicationRoleService
    {
        #region Async

        /// <summary>
        /// Найти пользователя по логину
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ApplicationUserDTO> FindByNameAsync(string userName);
        /// <summary>
        /// Найти пользователя по почте
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Task<ApplicationUserDTO> FindByEmailAsync(string Email);
        /// <summary>
        /// Найти пользователя по ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ApplicationUserDTO> FindByIdAsync(int userId);
        /// <summary>
        /// Добавить логин
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login);


        #region CRUD
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="applicationUserDTO"></param>
        /// <returns></returns>
        Task<OperationDetails> CreateOrUpdateAsync(ApplicationUserDTO applicationUserDTO);
        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="applicationUserDTO"></param>
        /// <returns></returns>
        Task<OperationDetails> UpdateUserRolesAsync(ApplicationUserDTO applicationUserDTO);
        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationDetails> DeleteAsync(int id);
        #endregion

        #endregion

        /// <summary>
        /// Найти пользователя по почте
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        ApplicationUserDTO FindByEmail(string Email);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<ApplicationUserDTO> GetApplicationUsers();


    }
}
