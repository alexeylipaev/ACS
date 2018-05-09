using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using AutoMapper;
using ACS.DAL.Entities;
using ACS.BLL.Infrastructure;

namespace ACS.BLL.Services
{
    public class TypeRecordChancelleryService : ServiceBase, ITypeRecordChancelleryService
    {
        public TypeRecordChancelleryService(IUnitOfWork uow) : base(uow) { }
        /// <summary>
        /// Все типы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery()
        {    // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TypeRecordChancellery>, List<TypeRecordChancelleryDTO>>(Database.TypeRecordChancelleries.GetAll());
        }

        public TypeRecordChancelleryDTO GetTypeRecordChancellery(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id", "");

            var type = Database.Employees.Find(id.Value);
            if (type == null)
                throw new ValidationException("Тип не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancellery>()).CreateMapper();

            return mapper.Map<Employee, TypeRecordChancelleryDTO>(type);
        }

        public void CreateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
