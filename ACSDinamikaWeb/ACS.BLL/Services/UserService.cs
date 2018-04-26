﻿using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;

using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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

            if (user != null)
                throw new ValidationException("Пользователь с таким ID уже создан", "");

            try
            {
                User User = new User
                {
                    LName = UserDTO.LName,
                    FName = UserDTO.FName,
                    MName = UserDTO.MName,

                    SID = UserDTO.SID,
                    Guid1C = UserDTO.Guid1C,

                    Birthday = UserDTO.Birthday,

                    PersonnelNumber = UserDTO.PersonnelNumber,

                };
                Database.Users.Create(User);
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
              
                SID = User.SID,
                Guid1C = User.Guid1C,

                Birthday = User.Birthday,
               
                PersonnelNumber = User.PersonnelNumber,

            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}