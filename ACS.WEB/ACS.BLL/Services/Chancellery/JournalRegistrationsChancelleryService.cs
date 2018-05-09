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
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<JournalRegistrationsChancellery>, List<JournalRegistrationsChancelleryDTO>>(Database.JournalRegistrationsChancelleries.GetAll());
        }


        JournalRegistrationsChancelleryDTO MappJournalToJournalDTO(JournalRegistrationsChancellery Journal)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
        }


        JournalRegistrationsChancellery MappJournalDTOToJournal(JournalRegistrationsChancelleryDTO JournalDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>()).CreateMapper();
            return mapper.Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>(JournalDto);
        }

        int CheckAuthorAndGetIndexAuthor(string authorEmail)
        {
            var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();
            var AuthorUser = Database.UserManager.FindByEmail(authorEmail);

            if (Author == null && AuthorUser == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", authorEmail);

            return Author != null ? Author.id : AuthorUser.Id;
        }

        private void CatchError(Exception e)
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
            throw e;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
