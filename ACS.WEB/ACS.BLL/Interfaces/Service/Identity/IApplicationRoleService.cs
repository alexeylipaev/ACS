using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IApplicationRoleService : IDisposable
    {
        /// <summary>
        /// Получить ID для будущего пользователя
        /// </summary>
        /// <returns></returns>
        int GetIdNewAppUser();


        ///// <summary>
        ///// Назначить роль
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //Task<OperationDetails> AssignRolesAsync(int userId);

        /// <summary>
        /// Получить роль пользователя
        /// </summary>
        /// <param name="RoleId">ID роли</param>
        /// <param name="UserId">ID пользователя</param>
        /// <returns></returns>
        AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null);

        /// <summary>
        /// Найти роль по ее ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApplicationRoleDTO FindRoleById(int id);

        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="applicationRoleDTO"></param>
        /// <returns></returns>
        Task<OperationDetails> CreateRoleAsync(ApplicationRoleDTO applicationRoleDTO);
        /// <summary>
        /// Найти роль по ее ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationRoleDTO> FindRoleByIdAsync(int id);
        /// <summary>
        /// Получить все роли
        /// </summary>
        /// <returns></returns>
        IEnumerable<ApplicationRoleDTO> GetApplicationRoles();
        /// <summary>
        /// Обновление роли
        /// </summary>
        /// <param name="applicationRoleDTO"></param>
        /// <returns></returns>
        Task<OperationDetails> UpdateRoleAsync(ApplicationRoleDTO applicationRoleDTO);
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationDetails> DeleteRoleAsync(int id);

        /// <summary>
        /// Находиться ли пользователь в данной роли
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool IsInRole(string username, string roleName);

    }
}
