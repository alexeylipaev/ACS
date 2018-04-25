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
        public void MakeUser(UserDTO UserDTO)
        {
            User user = Database.Users.Get(UserDTO.Id);

          
            User User = new User
            {
                LName = UserDTO.LName,
                FName = UserDTO.MName,
                MName = UserDTO.MName,
                //FullName = dataUser.ФИО,
                //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                SID = UserDTO.SID,
                Guid1C = UserDTO.Guid1C,

                Birthday = UserDTO.Birthday,
                //EMail = dataUserAD.Email,
                PersonnelNumber = UserDTO.PersonnelNumber,

                //Passport = new UserPassport()
                //{
                //    //паспортные данные
                //    DateOfIssue = UserDTO.Passport.DateOfIssue,
                //    IssuedBy = UserDTO.Passport.IssuedBy,
                //    Number =  UserDTO.Passport.Number,
                //    Series =  UserDTO.Passport.Series,
                //    UnitCode = UserDTO.Passport.UnitCode,
                //},
                

            };
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

            var User = Database.Users.Get(id.Value);
            if (User == null)
                throw new ValidationException("Пользователь не найден", "");

            return new UserDTO {
                LName = User.LName,
                FName = User.MName,
                MName = User.MName,
                //FullName = dataUser.ФИО,
                //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                SID = User.SID,
                Guid1C = User.Guid1C,

                Birthday = User.Birthday,
                //EMail = dataUserAD.Email,
                PersonnelNumber = User.PersonnelNumber,

                //Passport = new UserPassportDTO()
                //{
                //    //паспортные данные
                //    DateOfIssue = User.Passport.DateOfIssue,
                //    IssuedBy = User.Passport.IssuedBy,
                //    Number = User.Passport.Number,
                //    Series = User.Passport.Series,
                //    UnitCode = User.Passport.UnitCode,
                //},
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}