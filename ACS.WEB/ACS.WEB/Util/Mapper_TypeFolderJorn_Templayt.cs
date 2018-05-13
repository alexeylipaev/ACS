using ACS.BLL.DTO;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Util
{

     class Mapper_TypeFolderJorn_Templayt<DTO,VM>
    {
        private static Mapper_TypeFolderJorn_Templayt<DTO, VM> MapTypeChancelleryService;

        private Mapper_TypeFolderJorn_Templayt() { }


        public static Mapper_TypeFolderJorn_Templayt<DTO, VM> getMapper()
        {
            if (MapTypeChancelleryService == null)
            {
                MapTypeChancelleryService = new Mapper_TypeFolderJorn_Templayt<DTO, VM>();
            }
            return MapTypeChancelleryService;
        }

        public DTO Map_VM_to_DTO(VM VM)
        {
            return Mapper.Map<VM, DTO>(VM);
        }

        public VM Map_DTOto_VM(DTO DTO)
        {
            return Mapper.Map<DTO, VM>(DTO);
        }

        public IEnumerable<VM> MappListDTO_To_ListVM(IEnumerable<DTO> ListDTO)
        {
            return Mapper.Map<IEnumerable<DTO>, List<VM>>(ListDTO);
        }

        public IEnumerable<DTO> MappListVM_To_ListDTO(IEnumerable<VM> ListVM)
        {
            return Mapper.Map<IEnumerable<VM>, List<DTO>>(ListVM);
        }
    }
}