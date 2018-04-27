using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using ACS.DAL.Entities;
using AutoMapper;
using ACS.BLL.Infrastructure;
using ACS.BLL.BusinessModels;
using System.Diagnostics;
using System.Collections;

namespace ACS.BLL.Services
{


    public class ChancelleryService : IChancelleryService
    {
        IUnitOfWork Database { get; set; }

        public ChancelleryService(IUnitOfWork uow)
        {
            Database = uow;
        }
        /// <summary>
        /// Получить данные о файле по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFile(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id файла ", "");

            var File = Database.FileRecordChancelleries.Get(Id.Value);

            if (File == null)
                throw new ValidationException("Отсутствует ссылка на файл", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<FileRecordChancellery, FileRecordChancelleryDTO>(File);
        }


        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileRecordChancelleryDTO> GetAllFiles()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FileRecordChancellery>, List<FileRecordChancelleryDTO>>(Database.FileRecordChancelleries.GetAll());
        }

        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserDTO GetResponsible(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id ответственного", "");

            var User = Database.Users.Get(Id.Value);
            if (User == null)
                throw new ValidationException("Ответственный не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(User);
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> GetAllUser()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        /// <summary>
        /// Тип канцелярской записи
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TypeRecordChancelleryDTO GetType(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id типа", "");

            var type = Database.TypeRecordChancelleries.Get(Id.Value);
            if (type == null)
                throw new ValidationException("Тип не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(type);
        }

        /// <summary>
        /// Получить все типы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeRecordChancelleryDTO> GetAllTypes()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TypeRecordChancellery>, List<TypeRecordChancelleryDTO>>(Database.TypeRecordChancelleries.GetAll());
        }

        /// <summary>
        /// Получить канцеляскую запись по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ChancelleryDTO GetChancellery(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id канцелярской записи", "");

            var Chancellery = Database.Chancelleries.Get(Id.Value);

            if (Chancellery == null)
                throw new ValidationException("Канцелярская запись не найдена", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return mapper.Map<Chancellery, ChancelleryDTO>(Chancellery);
        }

        /// <summary>
        /// Получить всю канцелярию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ChancelleryDTO> GetChancelleries()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(Database.Chancelleries.GetAll());
        }




        /// <summary>
        /// Получить папку по ее ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FolderChancelleryDTO GetFolder(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id папки ", "");

            var Folder = Database.FolderChancelleries.Get(Id.Value);

            if (Folder == null)
                throw new ValidationException("Отсутствует папка", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return mapper.Map<FolderChancellery, FolderChancelleryDTO>(Folder);
        }

        /// <summary>
        /// Получить все папки
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FolderChancelleryDTO> GetAllFolders()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FolderChancellery>, List<FolderChancelleryDTO>>(Database.FolderChancelleries.GetAll());
        }



        /// <summary>
        /// Получить журнал канцелярии
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JournalRegistrationsChancelleryDTO GetJournalRegistrations(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id  ", "");

            var Journal = Database.JournalRegistrationsChancelleries.Get(Id.Value);

            if (Journal == null)
                throw new ValidationException("Отсутствует данные о журнале регистрации", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
        }

        /// <summary>
        /// все журналы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<JournalRegistrationsChancellery>, List<JournalRegistrationsChancelleryDTO>>(Database.JournalRegistrationsChancelleries.GetAll());
        }

        public FromChancelleryDTO GetFromWhom(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id  ", "");

            var from = Database.FromChancelleries.Get(Id.Value);

            if (from == null)
                throw new ValidationException("Отсутствует данные от кого", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FromChancellery, FromChancelleryDTO>()).CreateMapper();
            return mapper.Map<FromChancellery, FromChancelleryDTO>(from);
        }

        /// <summary>
        /// Кому (список)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ToChancelleryDTO> GetToList()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ToChancellery, ToChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ToChancellery>, List<ToChancelleryDTO>>(Database.ToChancelleries.GetAll());
        }


        public void MakeChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
            var Author = Database.Users.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (Author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, Chancellery>()).CreateMapper();
                Chancellery Chancellery = mapper.Map<ChancelleryDTO, Chancellery>(chancelleryDto);


                Database.Chancelleries.Create(Chancellery);
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


        public void UpdateChancellery(ChancelleryDTO ChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
