using ACS.BLL.DTO;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Mappings
{
    public class DTOToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DTOToViewModelMappings"; }
        }
        public DTOToViewModelMappingProfile()
        {
            CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();
            CreateMap<ApplicationUserDTO, ApplicationUserViewModel>();
            //CreateMap<ToChancelleryDTO, ToChancelleryViewModel>();
            CreateMap<EmployeeDTO, EmployeeViewModel>();
            CreateMap<AccessDTO, AccessViewModel>();
            CreateMap<BaseCorrespondencyDTO, ChancelleryViewModel>();
            CreateMap<PostEmployeeСode1СDTO, PostsEmployeeСode1СViewModel>();
            CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>();
            CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();
            CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();
            CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();
            CreateMap<BaseCorrespondencyDTO, IncomingCorrespondencyViewModel>();
                 //.ForMember(x => x.From, opt => opt.MapFrom(source => source.PropertyXYZ));
            CreateMap<BaseCorrespondencyDTO, OutgoingCorrespondencyViewModel>();
               //.ForMember(x => x.From, opt => opt.MapFrom(source => source.PropertyXYZ));
            CreateMap<BaseCorrespondencyDTO, InternalCorrespondencyViewModel>();
               //.ForMember(x => x.From, opt => opt.MapFrom(source => source.PropertyXYZ));
            CreateMap<BaseCorrespondencyDTO, ChancelleryViewModel>();
               //.ForMember(x => x.From, opt => opt.MapFrom(source => source.PropertyXYZ));

            //Mapper.CreateMap<X, XViewModel>()
            //    .ForMember(x => x.Property1, opt => opt.MapFrom(source => source.PropertyXYZ));
            //Mapper.CreateMap<Goal, GoalListViewModel>().ForMember(x => x.SupportsCount, opt => opt.MapFrom(source => source.Supports.Count))
            //                                          .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.User.UserName))
            //                                          .ForMember(x => x.StartDate, opt => opt.MapFrom(source => source.StartDate.ToString("dd MMM yyyy")))
            //                                          .ForMember(x => x.EndDate, opt => opt.MapFrom(source => source.EndDate.ToString("dd MMM yyyy")));
            //Mapper.CreateMap<Group, GroupsItemViewModel>().ForMember(x => x.CreatedDate, opt => opt.MapFrom(source => source.CreatedDate.ToString("dd MMM yyyy")));

            //Mapper.CreateMap<IPagedList<Group>, IPagedList<GroupsItemViewModel>>().ConvertUsing<PagedListConverter<Group, GroupsItemViewModel>>();
        }
    }

}