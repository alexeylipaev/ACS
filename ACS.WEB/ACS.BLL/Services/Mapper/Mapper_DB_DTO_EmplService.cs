using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{

    class Mapper_DB_DTO_EmplService : IMapper_DB_DTO_EmplService
    {
        private static Mapper_DB_DTO_EmplService MapEmpService;
        //IMapper imap;
        private Mapper_DB_DTO_EmplService()
        {
            //imap = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Access, AccessDTO>().ReverseMap();
            //    cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>().ReverseMap();
            //    cfg.CreateMap<Chancellery, ChancelleryDTO>().ReverseMap();
            //    cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            //    cfg.CreateMap<PostEmployeeСode1С, PostEmployeeСode1СDTO>().ReverseMap();
            //    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();

            //}).CreateMapper();
        }


        public static Mapper_DB_DTO_EmplService getMapper()
        {
            if (MapEmpService == null)
            {
                MapEmpService = new Mapper_DB_DTO_EmplService();
            }
            return MapEmpService;
        }

        public Employee Map_EmployeeDTO_to_Employee(EmployeeDTO EmployeeDTO)
        {
            return MapDALBLL.GetMapp().Map<EmployeeDTO, Employee>(EmployeeDTO);
        }

        public EmployeeDTO Map_Employee_to_EmployeeDTO(Employee Employee)
        {
            return MapDALBLL.GetMapp().Map<Employee, EmployeeDTO>(Employee);
        }

        public IEnumerable<EmployeeDTO> MappListEmplsToListEmplsDTO(IEnumerable<Employee> Empls)
        {
            return MapDALBLL.GetMapp().Map<IEnumerable<Employee>, List<EmployeeDTO>>(Empls);
        }

        public IEnumerable<Employee> MappListEmplsDTOToListEmpls(IEnumerable<EmployeeDTO> EmplsDTO)
        {
            return MapDALBLL.GetMapp().Map<IEnumerable<EmployeeDTO>, List<Employee>>(EmplsDTO);
        }
    }


}
