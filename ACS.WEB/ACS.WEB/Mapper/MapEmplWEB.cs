using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB
{
    public static class MapEmplWEB
    {
        public static EmployeeDTO emplVMToEmplDto(EmployeeViewModel emplVM)
        {
            EmployeeDTO EmplDto = new EmployeeDTO();

            EmplDto.Id = emplVM.Id;
            EmplDto.LName = emplVM.LName;
            EmplDto.MName = emplVM.MName;
            EmplDto.FName = emplVM.FName;
            EmplDto.Email = emplVM.Email;

            EmplDto.ApplicationUserId = emplVM.ApplicationUserId;
         
            return EmplDto;
        }
        public static EmployeeViewModel EmplDtoToemplVM(EmployeeDTO EmplDto)
        {
            EmployeeViewModel emplVM = new EmployeeViewModel();

            emplVM.Id = EmplDto.Id;
            emplVM.FullName = EmplDto.FullName;
            emplVM.LName = EmplDto.LName;
            emplVM.MName = EmplDto.MName;
            emplVM.FName = EmplDto.FName;
            emplVM.Email = EmplDto.Email;

            emplVM.ApplicationUserId = EmplDto.ApplicationUserId;
            MapSystemParamDTO_to_VM<EmployeeDTO, EmployeeViewModel>.FillParamDTO(EmplDto, ref emplVM);
            return emplVM;
        }
        public static List<EmployeeViewModel> ListEmplToListemplVM(IEnumerable<EmployeeDTO> emplsDto)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();

            foreach (var EmplDto in emplsDto)
                result.Add(EmplDtoToemplVM(EmplDto));

            return result;
        }

    }
}
