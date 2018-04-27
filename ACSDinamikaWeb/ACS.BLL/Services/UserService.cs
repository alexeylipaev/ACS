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
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        string UNIQEUserString(UserDTO UserData)
        {
            return String.Format("{0} {1} {2} {3}", Helper.RemoveSpacesBeginnEndStr(UserData.LName), Helper.RemoveSpacesBeginnEndStr(UserData.FName)
                , Helper.RemoveSpacesBeginnEndStr(UserData.MName), Helper.RemoveSpacesBeginnEndStr(UserData.Email));

        }

        string UNIQEUserString(User UserData)
        {
            return String.Format("{0} {1} {2} {3}", Helper.RemoveSpacesBeginnEndStr(UserData.LName), Helper.RemoveSpacesBeginnEndStr(UserData.FName)
      , Helper.RemoveSpacesBeginnEndStr(UserData.MName), Helper.RemoveSpacesBeginnEndStr(UserData.Email));
        }

        public void MakeUser(UserDTO UserDTO)
        {
            var resultString = UNIQEUserString(UserDTO);
            User user = Database.Users.Find(u => UNIQEUserString(u) == resultString).FirstOrDefault();

            if (user != null)
                throw new ValidationException(string.Format("Пользователь с данными {0} уже существует, его ID : {1}", resultString, user.Id), "");

            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
                User User = mapper.Map<UserDTO, User>(UserDTO);

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
        public void MakeUser(UserDTO UserDTO, string authorEmail)
        {

            var author = Database.Users.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);


            var resultString = UNIQEUserString(UserDTO);
            User user = Database.Users.Find(u => UNIQEUserString(u) == resultString).FirstOrDefault();

            if (user != null)
                throw new ValidationException(string.Format("Пользователь с данными {0} уже существует, его ID : {1}", resultString, user.Id), "");

            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
                User User = mapper.Map<UserDTO, User>(UserDTO);
                User.s_AuthorID = author.Id;
                User.s_EditorID = author.Id;
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

        public void UpdateUser(UserDTO UserDTO, string authorEmail)
        {
            var editor = Database.Users.Find(u => u.Email == authorEmail).FirstOrDefault();

            User EditableObj = Database.Users.Get(UserDTO.Id);

            if (editor == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);


            if (EditableObj == null)
                throw new ValidationException("Не возможно редактировать объект с ID", UserDTO.Id.ToString());

            
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
                EditableObj = mapper.Map<UserDTO, User>(UserDTO);
                EditableObj.s_EditorID = editor.Id;
                EditableObj.Email = UserDTO.Email;

                //Database.Users.Update(EditableObj);
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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(User);

        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}