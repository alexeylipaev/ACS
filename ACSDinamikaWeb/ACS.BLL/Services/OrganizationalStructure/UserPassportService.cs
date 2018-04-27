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
    public class UserPassportService : IUserPassportService
    {

        IUnitOfWork Database { get; set; }

        public UserPassportService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UserDTO GetUser(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id пользователя", "");

            var user = Database.Users.Get(Id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public UserPassportDTO GetUserPassport(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id паспорта", "");

            var Passport = Database.PassportDataUsers.Get(Id.Value);
            if (Passport == null)
                throw new ValidationException("Паспорт не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserPassport, UserPassportDTO>()).CreateMapper();
            return mapper.Map<UserPassport, UserPassportDTO>(Passport);
        }

        public IEnumerable<UserPassportDTO> GetUsersPassport()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserPassport, UserPassportDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserPassport>, List<UserPassportDTO>>(Database.PassportDataUsers.GetAll());
        }


        public void MakeUserPassport(UserPassportDTO UserPassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassport(UserPassportDTO UserPassportDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
