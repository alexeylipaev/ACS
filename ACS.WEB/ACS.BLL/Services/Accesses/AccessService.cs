using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.DAL.Entities;
using AutoMapper;
using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System.Diagnostics;
using System.Collections;

namespace ACS.BLL.Services
{
    public class AccessService : IAccessService
    {
        IUnitOfWork Database { get; set; }

        public AccessService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeAccess(AccessDTO AccessDto, string authorEmail)
        {
            var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (Author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);

            //Access access = Database.Accesses.Get(AccessDto.id);

            //// валидация
            //if (access != null)
            //    throw new ValidationException("Доступ с таким id уже создан", "");

            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccessDTO, Access>()).CreateMapper();
                Access Access = mapper.Map<AccessDTO, Access>(AccessDto);

                //Employee Employee = new Employee
                //{
                //    LName = UserDTO.LName,
                //    FName = UserDTO.FName,
                //    MName = UserDTO.MName,

                //    SID = UserDTO.SID,
                //    Guid1C = UserDTO.Guid1C,

                //    Birthday = UserDTO.Birthday,

                //    PersonnelNumber = UserDTO.PersonnelNumber,

                //};
                Database.Accesses.Create(Access, Author.id);
                Database.Save();
            }
            catch (Exception e)
            {


                Debug.WriteLine("Имя члена:               {0}", e.TargetSite);
                Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
                Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
                Debug.WriteLine("Message:                 {0}", e.Message);
                Debug.WriteLine("Source:                  {0}", e.Source);
                Debug.WriteLine("Help Link:               {0}", e.HelpLink);
                Debug.WriteLine("Stack:                   {0}", e.StackTrace);

                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("{0} : {1}", de.Key, de.Value);
            }
        }

        public IEnumerable<AccessDTO> GetAccesses()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Access, AccessDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Access>, List<AccessDTO>>(Database.Accesses.GetAll());
        }

        public AccessDTO GetAccess(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id доступа", "");

            var access = Database.Accesses.Get(id.Value);
            if (access == null)
                throw new ValidationException("Доступ не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Access, AccessDTO>()).CreateMapper();
            return mapper.Map<Access, AccessDTO>(access);
        }

        public EmployeeDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");

            var Employee = Database.Employees.Get(id.Value);
            if (Employee == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(Employee);
        }

        public void UpdateAccess(AccessDTO accessDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}