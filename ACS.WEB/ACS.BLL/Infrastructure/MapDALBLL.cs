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
using ACS.BLL.BusinessModels;

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
        #region Outgoing

        static IMapper outgoingCorrespondency_DTO_TO_DB;
        public static IMapper GetMap_Outgoing_DTO_TO_DB()
        {
            if (outgoingCorrespondency_DTO_TO_DB == null)
                outgoingCorrespondency_DTO_TO_DB = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ChancelleryDTO, OutgoingCorrespondency>()
                     .ForMember(x => x.To, opt => opt.ResolveUsing<OutgoingToCustomResolver>())
                       .ForMember(x => x.From, x => x.MapFrom(c => c.FromChancelleries.FirstOrDefault().Employee ?? null));
                }).CreateMapper();

            return outgoingCorrespondency_DTO_TO_DB;
        }

        public class OutgoingToCustomResolver : IValueResolver<ChancelleryDTO, OutgoingCorrespondency, IEnumerable<ExternalOrganizationChancelleryDTO>>
        {
            public IEnumerable<ExternalOrganizationChancelleryDTO> Resolve(ChancelleryDTO source, OutgoingCorrespondency destination, IEnumerable<ExternalOrganizationChancelleryDTO> member, ResolutionContext context)
            {
                ICollection<ExternalOrganizationChancelleryDTO> result = new List<ExternalOrganizationChancelleryDTO>();
                if (source.ToChancelleries != null)
                    foreach (var to in source.ToChancelleries)
                        result.Add(to.ExternalOrganization);


                return result;
            }
        }

        static IMapper outgoingCorrespondencyDB_TO_DTO;
        public static IMapper GetMap_OutgoingDB_TO_DTO()
        {
            if (outgoingCorrespondencyDB_TO_DTO == null)
                outgoingCorrespondencyDB_TO_DTO = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OutgoingCorrespondency, ChancelleryDTO>()
                     .ForMember(x => x.FromChancelleries, opt => opt.ResolveUsing<OutgoingToDTO_FromCustomResolver>())
                     .ForMember(x => x.ToChancelleries, opt => opt.ResolveUsing<OutgoingToDTO_ToCustomResolver>());
                }).CreateMapper();

            return outgoingCorrespondencyDB_TO_DTO;
        }

        public class OutgoingToDTO_FromCustomResolver : IValueResolver<OutgoingCorrespondency, ChancelleryDTO, ICollection<FromChancelleryDTO>>
        {
            public ICollection<FromChancelleryDTO> Resolve(OutgoingCorrespondency source, ChancelleryDTO destination, ICollection<FromChancelleryDTO> member, ResolutionContext context)
            {
                ICollection<FromChancelleryDTO> result = new List<FromChancelleryDTO>();
                if (source.From != null) result.Add(new FromChancelleryDTO { Employee = source.From });
                return result;
            }
        }

        public class OutgoingToDTO_ToCustomResolver : IValueResolver<OutgoingCorrespondency, ChancelleryDTO, ICollection<ToChancelleryDTO>>
        {
            public ICollection<ToChancelleryDTO> Resolve(OutgoingCorrespondency source, ChancelleryDTO destination, ICollection<ToChancelleryDTO> member, ResolutionContext context)
            {
                ICollection<ToChancelleryDTO> result = new List<ToChancelleryDTO>();
                if (source.To != null)
                    foreach (var to in source.To)
                        result.Add(new ToChancelleryDTO { ExternalOrganization = to });

                return result;
            }
        }

        #endregion
        #region Internal

        static IMapper internalCorrespondency_DTO_TO_DB;
        public static IMapper GetMap_Internal_DTO_TO_DB()
        {
            if (internalCorrespondency_DTO_TO_DB == null)
                internalCorrespondency_DTO_TO_DB = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ChancelleryDTO, InternalCorrespondency>()
                     .ForMember(x => x.To, opt => opt.ResolveUsing<InternalToCustomResolver>())
                     .ForMember(x => x.From, x => x.MapFrom(c => c.FromChancelleries.FirstOrDefault().Employee ?? null));
                }).CreateMapper();

            return internalCorrespondency_DTO_TO_DB;
        }

        public class InternalToCustomResolver : IValueResolver<ChancelleryDTO, InternalCorrespondency, IEnumerable<EmployeeDTO>>
        {
            public IEnumerable<EmployeeDTO> Resolve(ChancelleryDTO source, InternalCorrespondency destination, IEnumerable<EmployeeDTO> member, ResolutionContext context)
            {
                ICollection<EmployeeDTO> result = new List<EmployeeDTO>();
                if (source.ToChancelleries != null)
                    foreach (var to in source.ToChancelleries)
                        result.Add(to.Employee);
                  
                   
                return result;
            }
        }

        static IMapper internalCorrespondencyDB_TO_DTO;
        public static IMapper GetMap_InternalDB_TO_DTO()
        {
            if (internalCorrespondencyDB_TO_DTO == null)
                internalCorrespondencyDB_TO_DTO = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<InternalCorrespondency, ChancelleryDTO>()
                     .ForMember(x => x.FromChancelleries, opt => opt.ResolveUsing<InternalToDTO_FromCustomResolver>())
                     .ForMember(x => x.ToChancelleries, opt => opt.ResolveUsing<InternalToDTO_ToCustomResolver>());
                }).CreateMapper();

            return internalCorrespondencyDB_TO_DTO;
        }


        public class InternalToDTO_FromCustomResolver : IValueResolver<InternalCorrespondency, ChancelleryDTO, ICollection<FromChancelleryDTO>>
        {
            public ICollection<FromChancelleryDTO> Resolve(InternalCorrespondency source, ChancelleryDTO destination, ICollection<FromChancelleryDTO> member, ResolutionContext context)
            {
                ICollection<FromChancelleryDTO> result = new List<FromChancelleryDTO>();
                if (source.From != null) result.Add(new FromChancelleryDTO { Employee = source.From });
                return result;
            }
        }

        public class InternalToDTO_ToCustomResolver : IValueResolver<InternalCorrespondency, ChancelleryDTO, ICollection<ToChancelleryDTO>>
        {
            public ICollection<ToChancelleryDTO> Resolve(InternalCorrespondency source, ChancelleryDTO destination, ICollection<ToChancelleryDTO> member, ResolutionContext context)
            {
                ICollection<ToChancelleryDTO> result = new List<ToChancelleryDTO>();
                if (source.To != null)
                    foreach (var to in source.To)
                        result.Add(new ToChancelleryDTO { Employee = to });

                return result;
            }
        }

        #endregion

        #region Incoming

        static IMapper incomingCorrespondency_DTO_TO_DB;
        public static IMapper GetMap_Incoming_DTO_TO_DB()
        {
            if (incomingCorrespondency_DTO_TO_DB == null)
                incomingCorrespondency_DTO_TO_DB = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<ChancelleryDTO, IncomingCorrespondency>()
                .ForMember(x => x.To, x => x.MapFrom(c => c.ToChancelleries.FirstOrDefault().Employee ?? null))
                .ForMember(x => x.From, x => x.MapFrom(c => c.FromChancelleries.FirstOrDefault().ExternalOrganization ?? null));
           }).CreateMapper();

            return incomingCorrespondency_DTO_TO_DB;
        }

        //private class IncomingToCustomResolver : IValueResolver<ChancelleryDTO, IncomingCorrespondency, EmployeeDTO>
        //{
        //    public EmployeeDTO Resolve(ChancelleryDTO source, IncomingCorrespondency destination, EmployeeDTO member, ResolutionContext context)
        //    {
        //        EmployeeDTO result = null;
        //        if (source.ToChancelleries.Count() != 0) result = source.ToChancelleries.First().Employee ?? null;
        //        return result;
        //    }
        //}

        //private class IncomingFromCustomResolver : IValueResolver<ChancelleryDTO, IncomingCorrespondency, ExternalOrganizationChancelleryDTO>
        //{
        //    public ExternalOrganizationChancelleryDTO Resolve(ChancelleryDTO source, IncomingCorrespondency destination, ExternalOrganizationChancelleryDTO member, ResolutionContext context)
        //    {
        //        ExternalOrganizationChancelleryDTO result = null;
        //        if (source.FromChancelleries.Count() != 0) result = source.FromChancelleries.First().ExternalOrganization ?? null;
        //        return result;
        //    }
        //}

        static IMapper incomingCorrespondencyDB_TO_DTO;
        public static IMapper GetMap_IncomingDB_TO_DTO()
        {
            if (incomingCorrespondencyDB_TO_DTO == null)
                incomingCorrespondencyDB_TO_DTO = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<IncomingCorrespondency, ChancelleryDTO>()
                     .ForMember(x => x.FromChancelleries, opt => opt.ResolveUsing<IncomingToDTO_FromCustomResolver>())
                     .ForMember(x => x.ToChancelleries, opt => opt.ResolveUsing<IncomingToDTO_ToCustomResolver>());
                }).CreateMapper();

            return incomingCorrespondencyDB_TO_DTO;
        }


        public class IncomingToDTO_FromCustomResolver : IValueResolver<IncomingCorrespondency, ChancelleryDTO, ICollection<FromChancelleryDTO>>
        {
            public ICollection<FromChancelleryDTO> Resolve(IncomingCorrespondency source, ChancelleryDTO destination, ICollection<FromChancelleryDTO> member, ResolutionContext context)
            {

                ICollection<FromChancelleryDTO> result = new List<FromChancelleryDTO>();
                if (source.From != null) result.Add(new FromChancelleryDTO { ExternalOrganization = source.From });
                return result;
            }
        }

        public class IncomingToDTO_ToCustomResolver : IValueResolver<IncomingCorrespondency, ChancelleryDTO, ICollection<ToChancelleryDTO>>
        {
            public ICollection<ToChancelleryDTO> Resolve(IncomingCorrespondency source, ChancelleryDTO destination, ICollection<ToChancelleryDTO> member, ResolutionContext context)
            {

                ICollection<ToChancelleryDTO> result = new List<ToChancelleryDTO>();
                if (source.To != null) result.Add(new ToChancelleryDTO { Employee = source.To });
                return result;
            }
        }

        #endregion

        static IMapper mapperUpdateCreate;

        public static IMapper GetMapForUpdateOrCreate()
        {

            if (mapperUpdateCreate == null)
                mapperUpdateCreate = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<EmployeeDTO, Employee>()
                                           .ForMember(x => x.PostsEmployeesСode1С, opt => opt.Ignore());

                cfg.CreateMap<PostEmployeeСode1СDTO, PostEmployeeСode1С>();
                                //.ForMember(x => x.CodePost1C, x => x.MapFrom(c => Database.PostsEmployeesСode1С.Find((int)c.id)));
                cfg.CreateMap<ApplicationUserDTO, ApplicationUser>();
                cfg.CreateMap<AppUserClaimDTO, AppUserClaim>();
                cfg.CreateMap<AppUserLoginDTO, AppUserLogin>();
                cfg.CreateMap<AppUserRoleDTO, AppUserRole>();
                cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancellery>();
                cfg.CreateMap<AccessDTO, Access>();
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>()
                .ForMember(x => x.Chancelleries, x => x.MapFrom(c => c.Chancelleries));
                cfg.CreateMap<FolderChancelleryDTO, FolderChancellery>()
                .ForMember(x => x.Chancelleries, x => x.MapFrom(c => c.Chancelleries));
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>()
                .ForMember(x => x.Chancelleries, x => x.MapFrom(c => c.Chancelleries));
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancellery>();
                cfg.CreateMap<FromChancelleryDTO, FromChancellery>()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));
                cfg.CreateMap<ToChancelleryDTO, ToChancellery>()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));
                cfg.CreateMap<ChancelleryDTO, Chancellery>()
                .ForMember(x => x.ResponsibleEmployees, opt => opt.ResolveUsing<ResponsibleEmployees_DTOToDAL_Resolver>())
                //.ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.FolderChancellery, x => x.MapFrom(c => Database.FolderChancelleries.Find((int)c.FolderChancellery.id)))
                .ForMember(x => x.JournalRegistrationsChancellery, x => x.MapFrom(c => Database.JournalRegistrationsChancelleries.Find((int)c.JournalRegistrationsChancellery.id)))
                .ForMember(x => x.TypeRecordChancellery, x => x.MapFrom(c => Database.TypeRecordChancelleries.Find((int)c.TypeRecordChancellery.id)));


            }).CreateMapper();

            return mapperUpdateCreate;
        }

        public class ResponsibleEmployees_DTOToDAL_Resolver : IValueResolver<ChancelleryDTO, Chancellery, ICollection<Employee>>
        {
            public ICollection<Employee> Resolve(ChancelleryDTO source, Chancellery destination, ICollection<Employee> member, ResolutionContext context)
            {
                ICollection<Employee> result = new List<Employee>();
                if (source.ResponsibleEmployees != null) 
                        foreach(var emnpl in source.ResponsibleEmployees)
                        result.Add(Database.Employees.Find(emnpl.id));

                return result;
            }
        }

        static IMapper mapper;
        public static IMapper GetMapp()
        {
            if (mapper == null)
                mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Chancellery, ChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FromChancellery, FromChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
                    cfg.CreateMap<PostEmployeeСode1С, PostEmployeeСode1СDTO>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
                    cfg.CreateMap<AppUserClaim, AppUserClaimDTO>().ReverseMap();
                    cfg.CreateMap<AppUserLogin, AppUserLoginDTO>().ReverseMap();
                    cfg.CreateMap<AppUserRole, AppUserRoleDTO>().ReverseMap();
                    cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<ToChancellery, ToChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<Access, AccessDTO>().ReverseMap();
                    cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>().ReverseMap();
                    cfg.CreateMap<FromChancellery, FromChancelleryDTO>().ReverseMap();
                }).CreateMapper();

            return mapper;
        }
    }
}
