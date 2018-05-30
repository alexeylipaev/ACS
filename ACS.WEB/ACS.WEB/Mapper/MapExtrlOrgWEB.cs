using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACS.WEB
{
    public static class MapExtrlOrgWEB
    {
        public static ExternalOrganizationDTO ExtlOrgInputToExtlOrgDTO(ExternalOrganizationInput ExternalOrganizationInput)
        {
            ExternalOrganizationDTO ExtlOrgDto  = new ExternalOrganizationDTO();

            ExtlOrgDto.Id = ExternalOrganizationInput.Id;

            ExtlOrgDto.Address = ExternalOrganizationInput.Address;
            ExtlOrgDto.City = ExternalOrganizationInput.City;
            ExtlOrgDto.Email = ExternalOrganizationInput.Email;
            ExtlOrgDto.Name = ExternalOrganizationInput.Name;
            ExtlOrgDto.Phone = ExternalOrganizationInput.Phone;


            //MapSystemParam<ExternalOrganizationInput, ExternalOrganizationDTO>.FillParamDTO(ExternalOrganizationInput, ref ExtlOrgDto);

            return ExtlOrgDto;
        }

        public static ExternalOrganizationDTO ExtlOrgVMToExtlOrgDTO(ExternalOrganizationViewModel extlOrgVM)
        {
            ExternalOrganizationDTO ExtlOrgDto  = new ExternalOrganizationDTO();

            ExtlOrgDto.Id = extlOrgVM.Id;

            ExtlOrgDto.Address = extlOrgVM.Address;
            ExtlOrgDto.City = extlOrgVM.City;
            ExtlOrgDto.Email = extlOrgVM.Email;
            ExtlOrgDto.Name = extlOrgVM.Name;
            ExtlOrgDto.Phone = extlOrgVM.Phone;

            //MapSystemParam<ExternalOrganizationDTO , ExternalOrganizationViewModel>.FillParamDTO(ExtlOrgDto, ref extlOrgVM );

            return ExtlOrgDto;
        }
        public static ExternalOrganizationViewModel ExtlOrgDTOToExtlOrgVM(ExternalOrganizationDTO extlOrgDTO)
        {
            ExternalOrganizationViewModel extlOrgVM = new ExternalOrganizationViewModel();

            extlOrgVM.Id = extlOrgDTO.Id;

            extlOrgVM.Address = extlOrgDTO.Address;
            extlOrgVM.City = extlOrgDTO.City;
            extlOrgVM.Email = extlOrgDTO.Email;
            extlOrgVM.Name = extlOrgDTO.Name;
            extlOrgVM.Phone = extlOrgDTO.Phone;

            MapSystemParamDTO_to_VM<ExternalOrganizationDTO, ExternalOrganizationViewModel>.FillParamDTO(extlOrgDTO, ref extlOrgVM);
            return extlOrgVM;
        }
        public static List<ExternalOrganizationViewModel> ListExtlOrgDTOToListextlOrgVM(IEnumerable<ExternalOrganizationDTO> ExtlOrgsDto)
        {
            List<ExternalOrganizationViewModel> result = new List<ExternalOrganizationViewModel>();

            foreach (var ExtlOrgDto in ExtlOrgsDto)
                result.Add(ExtlOrgDTOToExtlOrgVM(ExtlOrgDto));

            return result;
        }

        public static  ExternalOrganizationInput ExternalOrganizationDTOToExternalOrganizationInput(ExternalOrganizationDTO ExternalOrganizationDTO)         {
            ExternalOrganizationInput ExternalOrganizationInput = new ExternalOrganizationInput();
            ExternalOrganizationInput.Id = ExternalOrganizationDTO.Id;

            ExternalOrganizationInput.Address = ExternalOrganizationDTO.Address;
            ExternalOrganizationInput.City = ExternalOrganizationDTO.City;
            ExternalOrganizationInput.Email = ExternalOrganizationDTO.Email;
            ExternalOrganizationInput.Name = ExternalOrganizationDTO.Name;
            ExternalOrganizationInput.Phone = ExternalOrganizationDTO.Phone;
            return ExternalOrganizationInput;
        }

    }
}
