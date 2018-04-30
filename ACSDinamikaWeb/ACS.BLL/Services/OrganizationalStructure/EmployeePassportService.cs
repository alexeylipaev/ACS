using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using ACS.BLL.Infrastructure;
using AutoMapper;
using ACS.DAL.Entities;

namespace ACS.BLL.Services
{
    public class EmployeePassportService : IEmployeePassportService
    {

        IUnitOfWork Database { get; set; }

        public EmployeePassportService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public EmployeeDTO GetUser(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id пользователя", "");

            var user = Database.Employees.Get(Id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(user);
        }

        public EmployeePassportDTO GetUserPassport(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id паспорта", "");

            var Passport = Database.EmployeesPassports.Get(Id.Value);
            if (Passport == null)
                throw new ValidationException("Паспорт не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeePassport, EmployeePassportDTO>()).CreateMapper();
            return mapper.Map<EmployeePassport, EmployeePassportDTO>(Passport);
        }

        public IEnumerable<EmployeePassportDTO> GetUsersPassport()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeePassport, EmployeePassportDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<EmployeePassport>, List<EmployeePassportDTO>>(Database.EmployeesPassports.GetAll());
        }


        public void MakeUserPassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
