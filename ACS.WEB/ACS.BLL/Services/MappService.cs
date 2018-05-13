using ACS.BLL.DTO;
using ACS.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
    static public class MappService
    {
        static IMapper mapper;
        public static IMapper GetMapp()
        {
            if (mapper == null)
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Chancellery, ChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FromChancellery, FromChancelleryDTO>();
                    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
                    cfg.CreateMap<PostEmployeeСode1С, PostEmployeeСode1СDTO>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
                    cfg.CreateMap<AppUserClaim, AppUserClaimDTO>();
                    cfg.CreateMap<AppUserLogin, AppUserLoginDTO>();
                    cfg.CreateMap<AppUserRole, AppUserRoleDTO>();
                    cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<ToChancellery, ToChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<Access, AccessDTO>().ReverseMap();
                    cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>().ReverseMap();

                }).CreateMapper();

            return mapper;


        }


    }
}
