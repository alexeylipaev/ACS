using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    static public class MapExtlOrg
    {
        public static DAL.Entities.ExternalOrganization ExtlOrgDTOToExtlOrg(DTO.ExternalOrganizationDTO extlOrgDto)
        {
            DAL.Entities.ExternalOrganization ExtlOrg = MapDB.Db.ExternalOrganization.Find(extlOrgDto.Id);

            if (ExtlOrg == null) ExtlOrg = new DAL.Entities.ExternalOrganization();

            ExtlOrg.Id = extlOrgDto.Id;

            ExtlOrg.Address = extlOrgDto.Address;
            ExtlOrg.City = extlOrgDto.City;
            ExtlOrg.Email = extlOrgDto.Email;
            ExtlOrg.Name = extlOrgDto.Name;
            ExtlOrg.Phone = extlOrgDto.Phone;

            return ExtlOrg;
        }
        public static DTO.ExternalOrganizationDTO ExtlOrgToExtlOrgDto(DAL.Entities.ExternalOrganization ExtlOrg)
        {
            DTO.ExternalOrganizationDTO extlOrgDto = new DTO.ExternalOrganizationDTO();

            extlOrgDto.Id = ExtlOrg.Id;

            extlOrgDto.Address = ExtlOrg.Address;
            extlOrgDto.City = ExtlOrg.City;
            extlOrgDto.Email = ExtlOrg.Email;
            extlOrgDto.Name = ExtlOrg.Name;
            extlOrgDto.Phone = ExtlOrg.Phone;

            BLL.MapSystemParamBLL<DAL.Entities.ExternalOrganization, DTO.ExternalOrganizationDTO>.FillParamDTO(ExtlOrg, ref extlOrgDto);
            return extlOrgDto;
        }
        public static List<DTO.ExternalOrganizationDTO> ListExtlOrgToListextlOrgDto(List<DAL.Entities.ExternalOrganization> ExtlOrgs)
        {
            List<DTO.ExternalOrganizationDTO> result = new List<DTO.ExternalOrganizationDTO>();

            foreach (var ExtlOrg in ExtlOrgs)
                result.Add(ExtlOrgToExtlOrgDto(ExtlOrg));

            return result;
        }

    }
}
