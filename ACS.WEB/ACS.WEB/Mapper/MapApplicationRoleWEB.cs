using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapApplicationRoleWEB
    {
        public static ApplicationRoleViewModel RoleDTOToRoleVM(ApplicationRoleDTO roleDto)         {
            ApplicationRoleViewModel roleVM = new ApplicationRoleViewModel();
            roleVM.Name = roleDto.Name;
            roleVM.id = roleDto.id;

            return roleVM;
        }
        public static List<ApplicationRoleViewModel> ListRoleDtoToListRoleVM(List<ApplicationRoleDTO> rolesDto)         {
            List<ApplicationRoleViewModel> result = new List<ApplicationRoleViewModel>();             foreach (var role in rolesDto)
            {
                result.Add(RoleDTOToRoleVM(role));
            }

            return result;
        }

    }
}
