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

        public IEnumerable<ASPRolesIdentityUserDTO> Find(Func<ASPRolesIdentityUserDTO, Boolean> predicate)
        {
            //var conv = new ExpressionConverter();
            //Expression<Func<ASPRolesIdentityUserDTO, bool>> bllExpr = mc => predicate(mc);
            //Expression <Func<ASPRolesIdentityUser, bool>> dllExpr = (Expression<Func<ASPRolesIdentityUser, bool>>)conv.Convert(bllExpr);
            Func<ASPRolesIdentityUser, bool> userPredicate = u => predicate(MapSourceToDest(u));
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ASPRolesIdentityUser, ASPRolesIdentityUserDTO>()).CreateMapper();
            
            return mapper.Map<IEnumerable<ASPRolesIdentityUser>, List<ASPRolesIdentityUserDTO>>(Database.ASPRolesIdentityUsers.Find(userPredicate));
        }

        ASPRolesIdentityUserDTO MapSourceToDest(ASPRolesIdentityUser v) {
            ASPRolesIdentityUserDTO dest = new ASPRolesIdentityUserDTO();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ASPRolesIdentityUserDTO, ASPRolesIdentityUser>()).CreateMapper();
            dest = mapper.Map<ASPRolesIdentityUser, ASPRolesIdentityUserDTO>(v);
            return dest;
        }

        public void MakeAccess(AccessDTO AccessDto, string authorEmail)
        {
            var Author = Database.Users.Find(u => u.Email == authorEmail).FirstOrDefault();

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

                //User User = new User
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
            var user = Database.ASPIdentityUsers.Find(u => u.Email == userEmail).FirstOrDefault();
            if (user != null)
            {
                var roles = Database.ASPRolesIdentityUsers.Find(r => r.Name==roleName && r.IdentityUser.Contains(user));
                result = roles.Count() > 0;
            }
            return result;
        }

        public ASPIdentityUserDTO GetIdentityUser(string username)
        {
            ASPIdentityUserDTO result = null;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ASPIdentityUser, ASPIdentityUserDTO>()).CreateMapper();
            var user = Database.ASPIdentityUsers.Find(u => u.UserName == username).FirstOrDefault();
            if (user != null)
                result = mapper.Map<ASPIdentityUser, ASPIdentityUserDTO>(user);
            return result;
        }

        public UserDTO GetUserDTO(string username)
        {
            UserDTO result = null;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var user = Database.Users.Find(u => u.Email == username).FirstOrDefault();
            if (user != null)
                result = mapper.Map<User, UserDTO>(user);
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

        public UserDTO GetUser(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id пользователя", "");

            var User = Database.Users.Get(Id.Value);
            if (User == null)
                throw new ValidationException("Пользователь не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(User);
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
                if (typeof(T) == typeof(Func<ASPRolesIdentityUserDTO, bool>))
                {
                    replaceParam = Expression.Parameter(typeof(ASPRolesIdentityUser), "p");
                    return Expression.Lambda<Func<ASPRolesIdentityUser, bool>>(Visit(node.Body), replaceParam);
                }
                return base.VisitLambda<T>(node);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == typeof(ASPRolesIdentityUser))
                    return replaceParam; // Expression.Parameter(typeof(DataObject), "p");
                return base.VisitParameter(node);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == typeof(ASPRolesIdentityUserDTO))
                {
                    var member = typeof(ASPRolesIdentityUser).GetMember(node.Member.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).FirstOrDefault();
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