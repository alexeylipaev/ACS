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

namespace ACS.BLL.Services
{
    public class AccessService : IAccessService
    {
        IUnitOfWork Database { get; set; }

        public AccessService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeAccess(AccessDTO AccessDto)
        {
            Access access = Database.Accesses.Get(AccessDto.Id);

            // валидация
            if (access != null)
                throw new ValidationException("Доступ с таким ID уже создан", "");

            Access Access = new Access
            {
           
            };

            //if (AccessDto.Passport != null)
            //    Access.Passport = new AccessPassport()
            //    {
            //        //паспортные данные
            //        DateOfIssue = AccessDto.Passport.DateOfIssue,
            //        IssuedBy = AccessDto.Passport.IssuedBy,
            //        Number = AccessDto.Passport.Number,
            //        Series = AccessDto.Passport.Series,
            //        UnitCode = AccessDto.Passport.UnitCode,
            //    };

            Database.Accesses.Create(Access);
            Database.Save();
        }

        public IEnumerable<AccessDTO> GetAccesses()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Access, AccessDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Access>, List<AccessDTO>>(Database.Accesses.GetAll());
        }

        public AccessDTO GetAccess(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id доступа", "");

            var Access = Database.Accesses.Get(id.Value);

            if (Access == null)
                throw new ValidationException("Доступ не найден", "");

            return new AccessDTO
            {
                
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}