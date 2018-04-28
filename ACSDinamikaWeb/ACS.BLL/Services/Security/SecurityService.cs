﻿using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
//using Microsoft.AspNet.Identity.EntityFramework;

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
using System.Linq.Expressions;

namespace ACS.BLL.Services
{
    public class SecurityService : ISecurityService
    {
        IUnitOfWork Database { get; set; }

        public SecurityService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ApplicationRoleDTO> Find(Func<ApplicationRoleDTO, Boolean> predicate)
        {
            //var conv = new ExpressionConverter();
            //Expression<Func<ApplicationRoleDTO, bool>> bllExpr = mc => predicate(mc);
            //Expression <Func<ApplicationRole, bool>> dllExpr = (Expression<Func<ApplicationRole, bool>>)conv.Convert(bllExpr);

            Func<ApplicationRole, bool> userPredicate = u => predicate(MapSourceToDest(u));
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();


            return mapper.Map<IEnumerable<ApplicationRole>, List<ApplicationRoleDTO>>(Database.ApplicationRoles.Find(userPredicate));

        }

        ApplicationRoleDTO MapSourceToDest(ApplicationRole v)
        {
            ApplicationRoleDTO dest = new ApplicationRoleDTO();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRole>()).CreateMapper();
            dest = mapper.Map<ApplicationRole, ApplicationRoleDTO>(v);
            return dest;
        }

        public void MakeAccess(AccessDTO AccessDto, string authorEmail)
        {
            var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (Author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);

            //Access access = Database.Accesses.Get(AccessDto.Id);

            //// валидация
            //if (access != null)
            //    throw new ValidationException("Доступ с таким Id уже создан", "");

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
                Database.Accesses.Create(Access);
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

        public bool IsUserInRole(string userEmail, string roleName)
        {
            bool result = false;
            var applicationUser = Database.ApplicationUsers.Find(u => u.Email == userEmail).FirstOrDefault();

            if (applicationUser != null)
            {
                var roleId = Database.RoleManager.FindByNameAsync(roleName).Id.ToString();
                //.ApplicationRoles.Find(r => r.Name == roleName && applicationUser.rol);
                return applicationUser.Roles.Any(r => r.RoleId == roleId);
            }
            return result;
        }

        public ApplicationUserDTO GetIdentityUser(string username)
        {
            ApplicationUserDTO result = null;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();
            var applicationUser = Database.ApplicationUsers.Find(u => u.UserName == username).FirstOrDefault();
            if (applicationUser != null)
                result = mapper.Map<ApplicationUser, ApplicationUserDTO>(applicationUser);
            return result;
        }

        public EmployeeDTO GetUserDTO(string username)
        {
            EmployeeDTO result = null;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            var employee = Database.Employees.Find(u => u.Email == username).FirstOrDefault();
            if (employee != null)
                result = mapper.Map<Employee, EmployeeDTO>(employee);
            return result;
        }

        public IEnumerable<AccessDTO> GetAccesses()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Access, AccessDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Access>, List<AccessDTO>>(Database.Accesses.GetAll());
        }

        public AccessDTO GetAccess(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id доступа", "");

            var access = Database.Accesses.Get(Id.Value);
            if (access == null)
                throw new ValidationException("Доступ не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Access, AccessDTO>()).CreateMapper();
            return mapper.Map<Access, AccessDTO>(access);
        }

        public EmployeeDTO GetUser(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id пользователя", "");

            var employee = Database.Employees.Get(Id.Value);
            if (employee == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public void UpdateAccess(AccessDTO accessDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        internal class ExpressionConverter : ExpressionVisitor
        {
            public Expression Convert(Expression expr)
            {
                return Visit(expr);
            }

            private ParameterExpression replaceParam;

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (typeof(T) == typeof(Func<ApplicationRoleDTO, bool>))
                {
                    replaceParam = Expression.Parameter(typeof(ApplicationRole), "p");
                    return Expression.Lambda<Func<ApplicationRole, bool>>(Visit(node.Body), replaceParam);
                }
                return base.VisitLambda<T>(node);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == typeof(ApplicationRole))
                    return replaceParam; // Expression.Parameter(typeof(DataObject), "p");
                return base.VisitParameter(node);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == typeof(ApplicationRoleDTO))
                {
                    var member = typeof(ApplicationRole).GetMember(node.Member.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).FirstOrDefault();
                    if (member == null)
                        throw new InvalidOperationException("Cannot identify corresponding member of DataObject");
                    return Expression.MakeMemberAccess(Visit(node.Expression), member);
                }
                return base.VisitMember(node);
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
