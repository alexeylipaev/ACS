using ACS.BLL.DTO;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Mappings
{
    // This is the approach starting with version 5
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<TypeRecordChancelleryViewModel, TypeRecordChancelleryDTO>();
            CreateMap<ApplicationUserViewModel, ApplicationUserDTO>();
            //CreateMap<ToChancelleryViewModel, ToChancelleryDTO>();
            CreateMap<EmployeeViewModel, EmployeeDTO>();
            CreateMap<AccessViewModel, AccessDTO>();
            CreateMap<ChancelleryViewModel, BaseCorrespondencyDTO>();
            CreateMap<PostsEmployeeСode1СViewModel, PostEmployeeСode1СDTO>();
            CreateMap<ExternalOrganizationChancelleryViewModel, ExternalOrganizationChancelleryDTO>();
            CreateMap<FolderChancelleryViewModel, FolderChancelleryDTO>();
            CreateMap<JournalRegistrationsChancelleryViewModel, JournalRegistrationsChancelleryDTO>();
            CreateMap<FileRecordChancelleryViewModel, FileRecordChancelleryDTO>();
            CreateMap<IncomingCorrespondencyViewModel, BaseCorrespondencyDTO>();
            CreateMap<OutgoingCorrespondencyViewModel, BaseCorrespondencyDTO>();
            CreateMap<InternalCorrespondencyViewModel, BaseCorrespondencyDTO>();
            CreateMap<ChancelleryViewModel, BaseCorrespondencyDTO>();
        }
    }
}