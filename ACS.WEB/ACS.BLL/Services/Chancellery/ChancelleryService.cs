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
using System.IO;

namespace ACS.BLL.Services
{


    public class ChancelleryService : ServiceBase, IChancelleryService
    {
        private ExternalOrganizationChancelleryService ExternalOrganizationChancelleryService;
        private EmployeeService EmployeeService;
        private JournalRegistrationsChancelleryService JournalRegistrationsChancelleryService;
        private FolderChancelleryService FolderChancelleryService;
        private TypeRecordChancelleryService TypeRecordChancelleryService;
        public ChancelleryService(IUnitOfWork uow) : base(uow)
        {
            ExternalOrganizationChancelleryService = new ExternalOrganizationChancelleryService(uow);
            EmployeeService = new EmployeeService(uow);
            JournalRegistrationsChancelleryService = new JournalRegistrationsChancelleryService(uow);
            FolderChancelleryService = new FolderChancelleryService(uow);
            TypeRecordChancelleryService = new TypeRecordChancelleryService(uow);
        }

        #region Канцелярия 




        public void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }
            try
            {
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, Chancellery>()).CreateMapper();
                Chancellery chancellery = GetMapChancelleryDTOToChancelleryDB().Map<ChancelleryDTO, Chancellery>(chancelleryDto);

                Database.Chancelleries.Add(chancellery, AuthorID);
                //Database.TypeRecordChancelleries.Update(chancellery.TypeRecordChancellery);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }


        public void ChancelleryUpdate(ChancelleryDTO chancelleryDTO, string editorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            Chancellery chancelleryDB = GetMapChancelleryDTOToChancelleryDB().Map<ChancelleryDTO, Chancellery>(chancelleryDTO);

            if (chancelleryDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", chancelleryDTO.id.ToString());

            try
            {
                Database.Chancelleries.Update(chancelleryDB, AuthorID);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }


        public int DeleteChancellery(int chancelleryId)
        {
            return Database.Chancelleries.Delete(chancelleryId);
        }

        /// <summary>
        /// Получить канцеляскую запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ChancelleryDTO ChancelleryGet(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id канцелярской записи", "");

            var Chancellery = Database.Chancelleries.Find(id);

            if (Chancellery == null)
                throw new ValidationException("Канцелярская запись не найдена", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<Chancellery, ChancelleryDTO>(Chancellery);
        }

        /// <summary>
        /// Получить всю канцелярию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ChancelleryDTO> ChancellerieGetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(Database.Chancelleries.GetAll().ToList());
        }

        #region Внешнии организации

        public ExternalOrganizationChancelleryDTO GetExternalOrganization(int id)
        {
            return ExternalOrganizationChancelleryService.GetExternalOrganization(id);
        }

        public IEnumerable<ExternalOrganizationChancelleryDTO> GetAllExternalOrganizations()
        {
            return ExternalOrganizationChancelleryService.GetExternalOrganizationsChancellery();
        }

        #endregion

        #region TypeRecordChancelleries

        /// <summary>
        /// Получить все типы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeRecordChancelleryDTO> TypeRecordGetAll()
        {
            return TypeRecordChancelleryService.GetTypesRecordChancellery();
        }


        /// <summary>
        /// Тип канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeRecordChancelleryDTO TypeRecordGetById(int id)
        {

            return TypeRecordChancelleryService.GetTypeRecordChancellery(id);
        }

        /// <summary>
        /// получить тип по имени
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public TypeRecordChancelleryDTO TypeRecordGetByName(string typeName)
        {
            return TypeRecordChancelleryService.GetTypeRecordByName(typeName);
        }

        public void TypeRecordCreateOrUpdate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            TypeRecordChancelleryService.CreateOrUpdateTypeRecordChancellery(typeDTO, currentUserEmail);
        }


        public void TypeRecordMoveToBasket(TypeRecordChancelleryDTO typeDTO, string authorEmail)
        {
            typeDTO.s_InBasket = true;
            TypeRecordChancelleryService.CreateOrUpdateTypeRecordChancellery(typeDTO, authorEmail);
        }

        public void TypeRecordDelete(int typeId)
        {
            TypeRecordChancelleryService.DeleteTypeRecordChancellery(typeId);
        }
        #endregion

        #region работа с папками

        /// <summary>
        /// Получить папку по ее ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FolderChancelleryDTO FolderGet(int id)
        {
            return FolderChancelleryService.GetFolderChancellery(id);
        }

        /// <summary>
        /// Получить все папки
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FolderChancelleryDTO> GetAllFolders()
        {
            return FolderChancelleryService.GetFoldersChancellery();
        }


        #endregion

        #region работа с журналами регистраций
        /// <summary>
        /// Получить журнал канцелярии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JournalRegistrationsChancelleryDTO GetJournalRegistrations(int id)
        {
            return JournalRegistrationsChancelleryService.GetJournal(id);
        }

        /// <summary>
        /// все журналы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations()
        {
            return JournalRegistrationsChancelleryService.GetJournalsChancellery();
        }
        #endregion

        #region от кого/кому

        public FromChancelleryDTO GetFromWhom(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id  ", "");

            var from = Database.FromChancelleries.Find(id);

            if (from == null)
                throw new ValidationException("Отсутствуют данные от кого", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FromChancellery, FromChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FromChancellery, FromChancelleryDTO>(from);
        }

        /// <summary>
        /// Кому (список)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ToChancelleryDTO> GetToList()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ToChancellery, ToChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<IEnumerable<ToChancellery>, List<ToChancelleryDTO>>(Database.ToChancelleries.GetAll());
        }

        #endregion

        #endregion

        #region работа с файлами 

        /// <summary>
        /// Получить данные о файле по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFileChanceller(int FileId)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id файла ", "");
            FileRecordChancellery File = null;

            File = (from ch in Database.Chancelleries.ToList()
                    where ch.FileRecordChancelleries.Any(f => f.id == FileId)
                    from file in ch.FileRecordChancelleries
                    select file).FirstOrDefault();


            if (File == null)
                throw new ValidationException("Запись не содержит файла с таким ID", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancellery, FileRecordChancelleryDTO>(File);
        }

        /// <summary>
        /// Получить данные о файле по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFile(int FileId)
        {
            FileRecordChancellery File = null;

            File = Database.FileRecordChancelleries.Find(FileId);

            if (File == null)
                throw new ValidationException("Файл с ID отсутствует", FileId.ToString());

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancellery, FileRecordChancelleryDTO>(File);
        }

        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileRecordChancelleryDTO> GetAllFiles()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<IEnumerable<FileRecordChancellery>, List<FileRecordChancelleryDTO>>(Database.FileRecordChancelleries.GetAll());
        }


        /// <summary>
        /// Получить связанный с канцелярией файл по его пути
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ChancelleryId"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFileChancellerByPath(string Path, int ChancelleryId)
        {
            FileRecordChancelleryDTO result = null;
            var files = Database.FileRecordChancelleries.Query(filter: f => f.Path == Path);

            foreach (var file in files)
            {
                var chancellery = (from ch in Database.Chancelleries.ToList()
                                   from f in ch.FileRecordChancelleries.ToList()
                                   where f.id == file.id
                                   select ch).FirstOrDefault();

                if (chancellery != null)
                {
                    result = MappFileRecordChancelleryToFileRecordChancelleryDTO(file);
                }
            }
            return result;
        }


        public IEnumerable<FileRecordChancelleryDTO> GetAllFilesChancellery(ChancelleryDTO Chancellery)
        {
            var Files = (from file in Chancellery.FileRecordChancelleries
                         select file);

            if (Files == null)
                throw new ValidationException("Запись не содержит файлов", "");
            return Files;
        }


        public int AttachOrDetachFile(FileRecordChancelleryDTO fileDTO, string authorEmail, int ChancelleryId, bool attach)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            FileRecordChancellery file = Database.FileRecordChancelleries.Find(fileDTO.id);

            if (file == null)//файла нет, создать нужно
            {
                FileRecordChancellery newFile = MappFileRecordChancelleryDTOTFileRecordChancellery(fileDTO);

                var Chanc = Database.Chancelleries.Find(ChancelleryId);

                Chanc.FileRecordChancelleries.Add(newFile);

                Database.Chancelleries.Update(Chanc, AuthorID);

            }
            else // файл есть
            {
                try
                {
                    file.Format = file.Format; file.Name = file.Name; file.Path = file.Path;

                    if (attach) // прикрепить
                        file.s_InBasket = false;
                    else file.s_InBasket = true;// открепить

                    return Database.FileRecordChancelleries.Update(file, AuthorID);

                }
                catch (Exception e)
                {
                    CatchError(e);
                }
            }

            return 0;
        }

        public int AttachOrDetachFiles(IEnumerable<FileRecordChancelleryDTO> filesDTO, string authorEmail, int ChancelleryId, bool attach)
        {
            int result = 0;
            foreach (var fileDTO in filesDTO)
            {
                result += AttachOrDetachFile(fileDTO, authorEmail, ChancelleryId, attach);
            }
            return result;
        }

        public int DeletedFile(FileRecordChancelleryDTO fileRecordChancelleryDTO)
        {
            int result = 0;
            try
            {
                File.Delete(fileRecordChancelleryDTO.Path);
                result++;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public int DeletedFiles(IEnumerable<FileRecordChancelleryDTO> files)
        {
            int result = 0;
            foreach (var file in files)
            {
                result += DeletedFile(file);
            }

            return result;
        }


        #endregion

        #region обращения к работникам

        /// <summary>
        /// Получить работника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDTO GetEmployee(int id)
        {
            return EmployeeService.GetEmployee(id);
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return EmployeeService.GetEmployees();
        }

        #endregion


        #region mappers
        IMapper GetMapChancelleryDTOToChancelleryDB()
        {

#warning таким образом были убраны баги с созданием копий
            var mapper = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>();
                cfg.CreateMap<FolderChancelleryDTO, FolderChancellery>();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancellery>();
                cfg.CreateMap<FromChancelleryDTO, FromChancellery>()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));
                cfg.CreateMap<ToChancelleryDTO, ToChancellery>()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.ExternalOrganization, x => x.MapFrom(c => Database.ExternalOrganizationChancelleries.Find((int)c.ExternalOrganization.id)));
                cfg.CreateMap<ChancelleryDTO, Chancellery>()
                .ForMember(x => x.Employee, x => x.MapFrom(c => Database.Employees.Find((int)c.Employee.id)))
                .ForMember(x => x.FolderChancellery, x => x.MapFrom(c => Database.FolderChancelleries.Find((int)c.FolderChancellery.id)))
                .ForMember(x => x.JournalRegistrationsChancellery, x => x.MapFrom(c => Database.JournalRegistrationsChancelleries.Find((int)c.JournalRegistrationsChancellery.id)))
                .ForMember(x => x.TypeRecordChancellery, x => x.MapFrom(c => Database.TypeRecordChancelleries.Find((int)c.TypeRecordChancellery.id)));


            }).CreateMapper();

            return mapper;
        }


        IMapper GetMapChancelleryDBToChancelleryDTO()
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{

            //    cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
            //    cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>();
            //    cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>();
            //    cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>();
            //    cfg.CreateMap<Chancellery, ChancelleryDTO>();

            //}).CreateMapper();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>();
                cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>();
                cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>();
                cfg.CreateMap<FromChancellery, FromChancelleryDTO>();
                cfg.CreateMap<ToChancellery, ToChancelleryDTO>();
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>();
                cfg.CreateMap<Chancellery, ChancelleryDTO>();
            }).CreateMapper();

            return mapper;
        }

        //IMapper GetMapEmployeeDBToDTO()
        //{
        //    var mapper = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<ApplicationUser, ApplicationUserDTO>();
        //        cfg.CreateMap<Chancellery, ChancelleryDTO>();
        //        cfg.CreateMap<Employee, EmployeeDTO>();


        //    }).CreateMapper();

        //    return mapper;
        //}

        IMapper GetMapTypeRecordChancelleryDBToTypeRecordChancelleryDTO()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chancellery, ChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();

            }).CreateMapper();

            return mapper;
        }

        IMapper GetMap_TypeRecordChancellery_DTO_To_DB()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, Chancellery>().ForMember(x => x.TypeRecordChancellery,
x => x.MapFrom(m => m.TypeRecordChancellery)); ;
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>();
            }).CreateMapper();

            return mapper;
        }


        #region маппер для файлов

        FileRecordChancelleryDTO MappFileRecordChancelleryToFileRecordChancelleryDTO(FileRecordChancellery FileRecordChancellery)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancellery, FileRecordChancelleryDTO>(FileRecordChancellery);
        }


        FileRecordChancellery MappFileRecordChancelleryDTOTFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDTO)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancellery>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancelleryDTO, FileRecordChancellery>(FileRecordChancelleryDTO);
        }

        #endregion

        #endregion

        public void Dispose()
        {
            Database.Dispose();
            ExternalOrganizationChancelleryService.Dispose();
            EmployeeService.Dispose();
            JournalRegistrationsChancelleryService.Dispose();
            FolderChancelleryService.Dispose();
            TypeRecordChancelleryService.Dispose();
        }
    }
}
