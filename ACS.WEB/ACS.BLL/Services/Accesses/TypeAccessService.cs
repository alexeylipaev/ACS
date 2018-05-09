using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.DAL.Interfaces;
using ACS.DAL.Entities;
using ACS.BLL.Infrastructure;

namespace ACS.BLL.Services
{
    public class TypeAccessService : ServiceBase, ITypeAccessService
    {
        public TypeAccessService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<TypeAccessDTO> GetTypesAccess()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeAccess, TypeAccessDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TypeAccess>, List<TypeAccessDTO>>(Database.TypesAccesses.GetAll());
        }

        public TypeAccessDTO GetTypeAccess(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id  ", "");

            var type = Database.TypesAccesses.Find(id.Value);

            if (type == null)
                throw new ValidationException("Отсутствует тип доступа", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeAccess, TypeAccessDTO>()).CreateMapper();
            return mapper.Map<TypeAccess, TypeAccessDTO>(type);
        }

        public void CreateTypeAccess(TypeAccessDTO TypeAccessDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateChancellery(TypeAccessDTO TypeAccessDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
