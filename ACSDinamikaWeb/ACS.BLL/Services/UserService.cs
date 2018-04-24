using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;

using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ACS.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeUser(UserDTO UserDto/*, CurrentUser Guid*/)
        {
            Access access = Database.Accesses.Get(Guid.NewGuid());

            // валидация
            if (access.TypeAccess.Name != "Редактирование")
                throw new ValidationException("Нет доступа на создание/редактирование обекта!", "");

            // применяем скидку
            // decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            User User = new User
            {
                LName = UserDto.LName,
                FName = UserDto.FName,
                MName = UserDto.MName,
                //FullName = dataUser.ФИО,
                //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                SID = UserDto.SID,
                Guid1C = UserDto.Guid1C,

                Birthday = UserDto.Birthday,
                //EMail = dataUserAD.Email,
                PersonnelNumber = UserDto.PersonnelNumber,

                //s_AuthorID = 1,
                //s_EditorID = 1,
            };

            //if (UserDto.Passport != null)
            //    User.Passport = new UserPassport()
            //    {
            //        //паспортные данные
            //        DateOfIssue = UserDto.Passport.DateOfIssue,
            //        IssuedBy = UserDto.Passport.IssuedBy,
            //        Number = UserDto.Passport.Number,
            //        Series = UserDto.Passport.Series,
            //        UnitCode = UserDto.Passport.UnitCode,
            //    };

            Database.Users.Create(User);
            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");

            var user = Database.Users.Get(id.Value);

            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return new UserDTO
            {
                LName = user.LName,
                FName = user.FName,
                MName = user.MName,
                //FullName = dataUser.ФИО,
                //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                SID = user.SID,
                Guid1C = user.Guid1C,

                Birthday = user.Birthday,
                //EMail = dataUserAD.Email,
                PersonnelNumber = user.PersonnelNumber,
                Passport = new UserPassportDTO()
                //{
                //    //паспортные данные
                //    DateOfIssue = user.Passport.DateOfIssue,
                //    IssuedBy = user.Passport.IssuedBy,
                //    Number = user.Passport.Number,
                //    Series = user.Passport.Series,
                //    UnitCode = user.Passport.UnitCode,

                //} 
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
