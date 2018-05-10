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
using System.Diagnostics;
using System.Collections;

namespace ACS.BLL.Services
{
    public class JournalRegistrationsChancelleryService :ServiceBase, IJournalRegistrationsChancelleryService
    {
        public JournalRegistrationsChancelleryService(IUnitOfWork uow) : base(uow) { }

        public int CreateOrUpdateJournal(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var journal = MappJournalDTOToJournal(JournalRegistrationsChancelleryDTO);

                var Journal = Database.JournalRegistrationsChancelleries.Find(JournalRegistrationsChancelleryDTO.id);

                if (Journal != null && Journal.Name != journal.Name)
                {
                    Journal.Name = journal.Name;
                    return Database.JournalRegistrationsChancelleries.Update(Journal, AuthorID);
                }

                else if (Journal == null)
                {
                    return Database.JournalRegistrationsChancelleries.Add(journal, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public int DeleteJournal(int id)
        {
            return Database.JournalRegistrationsChancelleries.Delete(id);
        }

        public IEnumerable<ChancelleryDTO> GetChancelleriesInJournal(int journalId)
        {
            var chancy = Database.Chancelleries.Query(filter: ch => ch.JournalRegistrationsChancellery.id == journalId).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(chancy);
        }

        public JournalRegistrationsChancelleryDTO GetJournal(int id)
        {
            var Journal = Database.JournalRegistrationsChancelleries.Find(id);

            if (Journal == null)
                throw new ValidationException("Отсутствует папка", "");

            return MappJournalToJournalDTO(Journal);
     
        }

        public IEnumerable<JournalRegistrationsChancelleryDTO> GetJournalsChancellery()
        {
            return mapTemplournalToJournalDTO().Map<IEnumerable<JournalRegistrationsChancellery>, List<JournalRegistrationsChancelleryDTO>>(Database.JournalRegistrationsChancelleries.GetAll());
        }

        IMapper mapTemplournalToJournalDTO()
        {
           return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chancellery, ChancelleryDTO>();
                cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>();

            }).CreateMapper();
        }


        JournalRegistrationsChancelleryDTO MappJournalToJournalDTO(JournalRegistrationsChancellery Journal)
        {
            return mapTemplournalToJournalDTO().Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
        }


        JournalRegistrationsChancellery MappJournalDTOToJournal(JournalRegistrationsChancelleryDTO JournalDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO , Chancellery>();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO , JournalRegistrationsChancellery>();

            }).CreateMapper();

           // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>()).CreateMapper();
            return mapper.Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>(JournalDto);
        }

        
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
