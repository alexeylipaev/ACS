using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapApplicationRole
    {
        public static DTO.ApplicationRoleDTO RoleToRoleDTO(DAL.Entities.ApplicationRole role)         {
            DTO.ApplicationRoleDTO roleDTO = new DTO.ApplicationRoleDTO();
            roleDTO.Name = role.Name;
            roleDTO.id = role.Id;

            return roleDTO;
        }
        public static List<DTO.ApplicationRoleDTO> ListRoleToListRoleDTO(List<DAL.Entities.ApplicationRole> roles)         {
            List<DTO.ApplicationRoleDTO> result = new List<DTO.ApplicationRoleDTO>();             foreach (var role in roles)
            {
                result.Add(MapApplicationRole.RoleToRoleDTO(role));
            }

            return result;
        }

    }
}
