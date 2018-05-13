using ACS.BLL.DTO;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Util
{
    public static class AutoMapperConfig
    {
        static public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>().ReverseMap();
                cfg.CreateMap<ToChancelleryDTO, ToChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<EmployeeDTO, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<AccessDTO, AccessViewModel>().ReverseMap();
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<PostEmployeeСode1СDTO, PostsEmployeeСode1СViewModel>().ReverseMap();
                cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>().ReverseMap();
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ReverseMap();
            });
        }

    }
}