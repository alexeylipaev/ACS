using ACS.BLL.DTO;
using ACS.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.Infrastructure;
using ACS.DAL.Interfaces;
namespace ACS.BLL
{
    static public class MapDALBLL
    {
        static public void Init(IUnitOfWork uow)
        {
            db = uow;
        }

        static private IUnitOfWork db;
        static private IUnitOfWork Database
        {
            get { return db; }
        }


        static IMapper mapper;
        public static IMapper GetMapp()
        {
            if (mapper == null)
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Chancellery, ChancelleryDTO>().ReverseMap()
                    .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                    .ForMember(x => x.FolderChancellery, x => x.MapFrom(c => Database.FolderChancelleries.Find((int)c.FolderChancellery.id)))
                    .ForMember(x => x.JournalRegistrationsChancellery, x => x.MapFrom(c => Database.JournalRegistrationsChancelleries.Find((int)c.JournalRegistrationsChancellery.id)))
                    .ForMember(x => x.TypeRecordChancellery, x => x.MapFrom(c => Database.TypeRecordChancelleries.Find((int)c.TypeRecordChancellery.id)));

                    cfg.CreateMap<ToChancellery, ToChancelleryDTO>().ReverseMap()
                            .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                          .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));

                    cfg.CreateMap<FromChancellery, FromChancelleryDTO>().ReverseMap()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));

                    cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>().ReverseMap();

                    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
                    cfg.CreateMap<PostEmployeeСode1С, PostEmployeeСode1СDTO>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
                    cfg.CreateMap<AppUserClaim, AppUserClaimDTO>().ReverseMap();
                    cfg.CreateMap<AppUserLogin, AppUserLoginDTO>().ReverseMap();
                    cfg.CreateMap<AppUserRole, AppUserRoleDTO>().ReverseMap();
                    cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>().ReverseMap();

                    cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<Access, AccessDTO>().ReverseMap();
                    cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FromChancelleryDTO, FromChancellery>().ReverseMap();
                }).CreateMapper();

            return mapper;


        }


    }
}
