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
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

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

        public void MakeUser(EmployeeDTO UserDTO)
        {
            var resultString = UNIQEUserString(UserDTO);
            Employee user = Database.Employees.Find(u => UNIQEUserString(u) == resultString).FirstOrDefault();

            if (user != null)
                throw new ValidationException(string.Format("Пользователь с данными {0} уже существует, его Id : {1}", resultString, user.Id), "");

            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, Employee>()).CreateMapper();
                Employee Employee = mapper.Map<EmployeeDTO, Employee>(UserDTO);

                Database.Employees.Create(Employee);
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

        public void MakeUser(EmployeeDTO UserDTO, string authorEmail)
        {

            var author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);


            var resultString = UNIQEUserString(UserDTO);
            Employee user = Database.Employees.Find(u => UNIQEUserString(u) == resultString).FirstOrDefault();

            if (user != null)
                throw new ValidationException(string.Format("Пользователь с данными {0} уже существует, его Id : {1}", resultString, user.Id), "");

            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, Employee>()).CreateMapper();
                Employee Employee = mapper.Map<EmployeeDTO, Employee>(UserDTO);
                Employee.s_AuthorID = author.Id;
                Employee.s_EditorID = author.Id;
                Database.Employees.Create(Employee);
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

        public void UpdateUser(EmployeeDTO UserDTO, string authorEmail)
        {

            Employee EditableObj = Database.Employees.Get(UserDTO.Id);

            var editor = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (editor == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);

            if (EditableObj == null)
                throw new ValidationException("Не возможно редактировать объект с Id", UserDTO.Id.ToString());

            try
            {
                EditableObj.LName = UserDTO.LName;
                EditableObj.FName = UserDTO.FName;
                EditableObj.MName = UserDTO.MName;
                //EditableObj.Email = UserDTO.Email;

                //EditableObj.s_EditDate = DateTime.Now;
                EditableObj.s_EditorID = editor.Id;

                Database.Employees.Update(EditableObj);
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

        public IEnumerable<EmployeeDTO> GetUsers()
        {
      
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }

        public EmployeeDTO GetUser(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id пользователя", "");

            var Employee = Database.Employees.Get(Id.Value);
            if (Employee == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(Employee);

        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}