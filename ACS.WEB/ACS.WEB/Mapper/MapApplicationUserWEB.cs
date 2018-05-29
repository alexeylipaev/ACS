using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapApplicationUserWEB
    {

        public static ApplicationUserDTO UserVMToUserDTO(ApplicationUserViewModel userVM)         {

            ApplicationUserDTO userDto = new ApplicationUserDTO();
            userDto.id = userVM.id;
            userDto.Email = userVM.Email;
            userDto.UserName = userVM.UserName;
            userDto.PasswordHash = userVM.PasswordHash;
            userDto.SecurityStamp = userVM.SecurityStamp;
            userDto.EmployeeId = userVM.EmployeeId;
            return userDto;
        }
        public static ApplicationUserViewModel UserDTOToUserVM(ApplicationUserDTO userDTO)         {
            ApplicationUserViewModel userVM = new ApplicationUserViewModel();
            userVM.id = userDTO.id;
            userVM.Email = userDTO.Email;
            userVM.UserName = userDTO.UserName;
            userVM.PasswordHash = userDTO.PasswordHash;
            userVM.SecurityStamp = userDTO.SecurityStamp;
            userVM.EmployeeId = userDTO.EmployeeId;
            userVM.Claims = userDTO.Claims;
            userVM.Logins = from login in userDTO.Logins
                            select new AppUserLoginViewModel() { LoginProvider = login.LoginProvider, ProviderKey = login.ProviderKey, UserId = login.UserId };
            userVM.Roles = from Role in userDTO.Roles
                           select new AppUserRoleViewModel() { RoleId = Role.RoleId, UserId = Role.UserId };

            return userVM;
        }
        public static List<ApplicationUserViewModel> ListUserDtoToListUserVM(List<ApplicationUserDTO> usersDto)         {
            List<ApplicationUserViewModel> result = new List<ApplicationUserViewModel>();             foreach (var userDto in usersDto)
            {
                result.Add(UserDTOToUserVM(userDto));
            }

            return result;
        }

    }
}
