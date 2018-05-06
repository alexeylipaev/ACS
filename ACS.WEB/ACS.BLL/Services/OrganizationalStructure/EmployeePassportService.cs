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

        public EmployeeDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");

            var user = Database.Employees.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(user);
        }

        public EmployeePassportDTO GetEmployeePassport(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id паспорта", "");

            var Passport = Database.EmployeesPassports.Get(id.Value);
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


        public void MakeEmployeePassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeePassport(EmployeePassportDTO EmployeePassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
