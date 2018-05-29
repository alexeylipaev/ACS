using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapApplicationUser
    {

        public static DAL.Entities.ApplicationUser UserDTOToUser(DTO.ApplicationUserDTO userDTO)         {
          
            DAL.Entities.ApplicationUser user = MapDB.Db.UserManager.FindById(userDTO.id);
            user.Id = userDTO.id;
            user.Email = userDTO.Email;
            user.UserName = userDTO.UserName;
            user.PasswordHash = userDTO.PasswordHash;
            user.SecurityStamp = userDTO.SecurityStamp;
            user.Employee = userDTO.EmployeeId != null ? MapDB.Db.Employees.Find(userDTO.EmployeeId.Value) : null;

            return user;
        }
        public static DTO.ApplicationUserDTO UserToUserDTO(DAL.Entities.ApplicationUser user)         {
            DTO.ApplicationUserDTO userDTO = new DTO.ApplicationUserDTO();
            userDTO.id = user.Id;
            userDTO.Email = user.Email;
            userDTO.UserName = user.UserName;
            userDTO.PasswordHash = user.PasswordHash;
            userDTO.SecurityStamp = user.SecurityStamp;
            userDTO.EmployeeId = user.Employee.Id;
            userDTO.Claims = user.Claims.Select(o => o.Id);
            userDTO.Logins = from login in user.Logins
                             select new DTO.AppUserLoginDTO() { LoginProvider = login.LoginProvider, ProviderKey = login.ProviderKey, UserId = login.UserId };
            userDTO.Roles = from Role in user.Roles
                            select new DTO.AppUserRoleDTO() { RoleId = Role.RoleId, UserId = Role.UserId };

            return userDTO;
        }
        public static List<DTO.ApplicationUserDTO> ListUserToListUserDTO(List<DAL.Entities.ApplicationUser> users)         {
            List<DTO.ApplicationUserDTO> result = new List<DTO.ApplicationUserDTO>();             foreach (var user in users)
            {
                result.Add(MapApplicationUser.UserToUserDTO(user));
            }

            return result;
        }

    }
}
