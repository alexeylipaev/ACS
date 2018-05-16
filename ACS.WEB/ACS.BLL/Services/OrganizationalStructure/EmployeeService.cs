using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;

using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ACS.BLL.BusinessModels;
namespace ACS.BLL.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {

        public EmployeeService(IUnitOfWork uow) : base(uow) {  }

        string UNIQEUserString(EmployeeDTO UserData)
        {
            return String.Format("{0} {1} {2} {3}", Helper.RemoveSpacesBeginnEndStr(UserData.LName), Helper.RemoveSpacesBeginnEndStr(UserData.FName)
                , Helper.RemoveSpacesBeginnEndStr(UserData.MName), Helper.RemoveSpacesBeginnEndStr(UserData.Email));

        }

        string UNIQEUserString(Employee UserData)
        {
            return String.Format("{0} {1} {2} {3}", Helper.RemoveSpacesBeginnEndStr(UserData.LName), Helper.RemoveSpacesBeginnEndStr(UserData.FName)
      , Helper.RemoveSpacesBeginnEndStr(UserData.MName), Helper.RemoveSpacesBeginnEndStr(UserData.Email));
        }

        public void CreateEmployee(EmployeeDTO EmplDTO)
        {
            var resultString = UNIQEUserString(EmplDTO);
            Employee author = Database.Employees.Find(u => UNIQEUserString(u) == resultString).FirstOrDefault();

            if (author != null)
                throw new ValidationException(string.Format("Пользователь с данными {0} уже существует, его id : {1}", resultString, author.id), "");

            try
            {
               
                Employee Employee = MapDALBLL.GetMapp().Map<EmployeeDTO , Employee>(EmplDTO);

                Database.Employees.Add(Employee, author.id);
              
            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }



        public void CreateOrUpdateEmpl(EmployeeDTO EmplDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var EmplOriginal = Database.Employees.Find(EmplDTO.id);
                /*   var chanceller =*/

                var Empl = MapDALBLL.GetMapForUpdateOrCreate().Map(EmplDTO, EmplOriginal);

                if (EmplOriginal != null)
                {
                    //CraeateOrUpdate_FromAndTo(chancellery, AuthorID);
                    Database.Employees.Update(EmplOriginal, AuthorID);
                }

                else if (EmplOriginal == null)
                {
                    //CraeateOrUpdate_FromAndTo(chancelleryDTO, AuthorID);
                    Database.Employees.Add(Empl, AuthorID);
                }

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }
         
        public void MoveToBasketEmployee(int userId, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            Employee EditableObj = Database.Employees.Find(userId);

            if (EditableObj == null)
                throw new ValidationException("Не возможно редактировать объект с id", userId.ToString());

            try
            {
                EditableObj.s_InBasket = true;
                Database.Employees.Update(EditableObj, AuthorID);
              
            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }

        public void DeleteEmployee(int userId)
        {
            Employee EditableObj = Database.Employees.Find(userId);

            if (EditableObj == null)
                throw new ValidationException("Не возможно редактировать объект с id", userId.ToString());

            try
            {

                Database.Employees.Delete(userId);
             
            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }

        private ApplicationUser GetEditor(string authorEmail)
        {
            return Database.UserManager.FindByEmail(authorEmail);
        }


//        IMapper GetMapEmplToEmpDto()
//        {
//            var mapper = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Access, AccessDTO>().ForMember(x => x.Employee_Id,
//x => x.MapFrom(m => m.Employee.id));
//                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
//                cfg.CreateMap<Chancellery, ChancelleryDTO>().ForMember(x => x.Employee,
//x => x.MapFrom(m => m.Employee)).ForMember(x => x.TypeRecordChancellery,
//x => x.MapFrom(m => m.TypeRecordChancellery));
//                cfg.CreateMap<ApplicationUser, ApplicationEmplDTO>().ForMember(x => x.Employee,
//          x => x.MapFrom(m => m.Employee));
//                cfg.CreateMap<PostEmployeeСode1С, PostEmployeeСode1СDTO>().ForMember(x => x.Employee_Id,
//x => x.MapFrom(m => m.Employee.id));
//                cfg.CreateMap<Employee, EmployeeDTO>();

//            }).CreateMapper();

//            return mapper;
//        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {

            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
            IEnumerable<Employee> Employees = Database.Employees.GetAll().ToList();

            IEnumerable<EmployeeDTO> result = MapDALBLL.GetMapp().Map<IEnumerable<Employee>, List<EmployeeDTO >>(Employees);
            //if (Employees.Any(e => e != null))
            return result;

            //return new List<EmployeeDTO>();
        }

        public EmployeeDTO GetEmployee(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");

            var Employee = Database.Employees.Find(id.Value);
            if (Employee == null)
                throw new ValidationException("Пользователь не найден", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<Employee , EmployeeDTO>(Employee);

        }

        public void Dispose()
        {
            Database.Dispose();

        }
    }
}