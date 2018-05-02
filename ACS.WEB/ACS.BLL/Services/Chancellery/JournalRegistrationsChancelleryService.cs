using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using AutoMapper;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;

namespace ACS.BLL.Services
{
    public class JournalRegistrationsChancelleryService : IJournalRegistrationsChancelleryService
    {
        IUnitOfWork Database { get; set; }

        public JournalRegistrationsChancelleryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<JournalRegistrationsChancelleryDTO> GetJournalsRegistrationsChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<JournalRegistrationsChancellery>, List<JournalRegistrationsChancelleryDTO>>(Database.JournalRegistrationsChancelleries.GetAll());
        }

        public JournalRegistrationsChancelleryDTO GetJournalRegistrationsChancellery(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id  ", "");

            var Journal = Database.JournalRegistrationsChancelleries.Get(Id.Value);

            if (Journal == null)
                throw new ValidationException("Отсутствует данные о журнале регистрации", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
        }

        public void MakeJournalRegistrationsChancellery(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateJournalRegistrationsChancellery(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
