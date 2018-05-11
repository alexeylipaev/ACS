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
        public ChancelleryService(IUnitOfWork uow) : base(uow) { }


        public void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
#warning к обсуждению, среди кого искать автора, Учетныйх записией или работников, не увсех работников есть почта, но у всех учеток она есть
            //var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();
            var AuthorUser = Database.UserManager.FindByEmail(authorEmail);
            if (/*Author == null && */AuthorUser == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", authorEmail);
            try
            {
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, Chancellery>()).CreateMapper();
                Chancellery chancellery = GetMapChancelleryDTOToChancelleryDB().Map<ChancelleryDTO, Chancellery>(chancelleryDto);

                int AuthorId = /*Author != null ? Author.id  : */AuthorUser.Id;

                Database.Chancelleries.Add(chancellery, AuthorId);
                //Database.TypeRecordChancelleries.Update(chancellery.TypeRecordChancellery);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }


        public void ChancelleryUpdate(ChancelleryDTO chancelleryDTO, string editorEmail)
        {

            Chancellery chancelleryDB = GetMapChancelleryDTOToChancelleryDB().Map<ChancelleryDTO, Chancellery>(chancelleryDTO);

            var editor = this.Database.UserManager.FindByEmail(editorEmail);

            if (editor == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", editorEmail);

            if (chancelleryDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", chancelleryDTO.id.ToString());

            try
            {
                Database.Chancelleries.Update(chancelleryDB, editor.Id);

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


        #region обращения к работникам

        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDTO GetResponsible(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id ответственного", "");

            var Employee = Database.Employees.Find(id);
            if (Employee == null)
                throw new ValidationException("Ответственный не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(Employee);
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDTO> GetAllUser()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }

        #endregion

        #region работа с файлами 

        /// <summary>
        /// Получить данные о файле по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFile(int FileId)
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

        public IEnumerable<FileRecordChancelleryDTO> GetAllFilesChancellery(ChancelleryDTO Chancellery)
        {
            var Files = (from file in Chancellery.FileRecordChancelleries
                     select file);

            if (Files == null)
                throw new ValidationException("Запись не содержит файлов", "");
            return Files;
        }



        public int AttachOrDetachFile(FileRecordChancelleryDTO fileDTO, string authorEmail, bool attach)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }


            FileRecordChancellery file = Database.FileRecordChancelleries.Find(fileDTO.id);

            if (file == null)
            {
                FileRecordChancellery newFile = new FileRecordChancellery()
                {
                    Format = file.Format,
                    Name = file.Name,
                    Path = file.Path
                };

                Database.FileRecordChancelleries.Add(newFile, AuthorID);
            }
            else
            {
                try
                {
                    file.Format = file.Format; file.Name = file.Name; file.Path = file.Path;

                    if (attach)
                        file.s_InBasket = false;
                    else file.s_InBasket = true;

                    return Database.FileRecordChancelleries.Update(file, AuthorID);

                }
                catch (Exception e)
                {
                    CatchError(e);
                }
            }

            return 0;
        }

        public int AttachOrDetachFiles(IEnumerable<FileRecordChancelleryDTO> filesDTO, string authorEmail, bool attach)
        {
            int result = 0;
            foreach (var fileDTO in filesDTO)
            {
                result += AttachOrDetachFile(fileDTO, authorEmail, attach);
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



        #region работа с папками

        /// <summary>
        /// Получить папку по ее ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FolderChancelleryDTO FolderGet(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id папки ", "");

            var Folder = Database.FolderChancelleries.Find(id);

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
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<IEnumerable<FolderChancellery>, List<FolderChancelleryDTO>>(Database.FolderChancelleries.GetAll());
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
            //if (id == null)
            //    throw new ValidationException("Не установлено id  ", "");

            var Journal = Database.JournalRegistrationsChancelleries.Find(id);

            if (Journal == null)
                throw new ValidationException("Отсутствуют данные о журнале регистрации", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
        }

        /// <summary>
        /// все журналы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<IEnumerable<JournalRegistrationsChancellery>, List<JournalRegistrationsChancelleryDTO>>(Database.JournalRegistrationsChancelleries.GetAll());
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
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ToChancellery, ToChancelleryDTO>()).CreateMapper();
            return GetMapChancelleryDBToChancelleryDTO().Map<IEnumerable<ToChancellery>, List<ToChancelleryDTO>>(Database.ToChancelleries.GetAll());
        }

        #endregion



        #region TypeRecordChancelleries

        /// <summary>
        /// Получить все типы канцелярии
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeRecordChancelleryDTO> TypeRecordGetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return GetMapTypeRecordChancelleryDBToTypeRecordChancelleryDTO().Map<IEnumerable<TypeRecordChancellery>, List<TypeRecordChancelleryDTO>>(Database.TypeRecordChancelleries.GetAll().ToList());
        }



        /// <summary>
        /// Тип канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeRecordChancelleryDTO TypeRecordGetById(int id)
        {

            var type = Database.TypeRecordChancelleries.Find(id);
            if (type == null)
                throw new ValidationException("Тип не найден", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return GetMapTypeRecordChancelleryDBToTypeRecordChancelleryDTO().Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(type);
        }

        public TypeRecordChancelleryDTO TypeRecordGetByName(string typeName)
        {
            var type = Database.TypeRecordChancelleries.Find(t=> t.Name == typeName).FirstOrDefault();
            if (type == null)
                throw new ValidationException("Тип не найден", "");

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>()).CreateMapper();
            return GetMapTypeRecordChancelleryDBToTypeRecordChancelleryDTO().Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(type);
        }

        public void TypeRecordCreate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            var Author = Database.Employees.Find(u => u.Email == currentUserEmail).FirstOrDefault();

            if (Author == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", currentUserEmail);
            try
            {
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, Chancellery>()).CreateMapper();
                TypeRecordChancellery typeDB = GetMap_TypeRecordChancellery_DTO_To_DB().Map<TypeRecordChancelleryDTO, TypeRecordChancellery>(typeDTO);
                Database.TypeRecordChancelleries.Add(typeDB, Author.id);
                //Database.TypeRecordChancelleries.Update(chancellery.TypeRecordChancellery);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }
        public void TypeRecordUpdate(TypeRecordChancelleryDTO typeDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            TypeRecordChancellery typeDB = GetMapChancelleryDTOToChancelleryDB().Map<TypeRecordChancelleryDTO, TypeRecordChancellery>(typeDTO);

            if (typeDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", typeDTO.id.ToString());

            try
            {
                Database.TypeRecordChancelleries.Update(typeDB, AuthorID);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }

        public void TypeRecordMoveToBasket(TypeRecordChancelleryDTO typeDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            TypeRecordChancellery typeDB = Database.TypeRecordChancelleries.Find(typeDTO.id);

            if (typeDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", typeDTO.id.ToString());

            try
            {
                typeDB.s_InBasket = true;
                Database.TypeRecordChancelleries.Update(typeDB, AuthorID);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }

        public void TypeRecordDelete(int typeId)
        {
            try
            {
                Database.TypeRecordChancelleries.Delete(typeId);

            }
            catch (Exception e)
            {
                CatchError(e);
            }
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
                cfg.CreateMap<FromChancelleryDTO, FromChancellery>();
                cfg.CreateMap<ToChancelleryDTO, ToChancellery>();
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
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
                cfg.CreateMap<Chancellery, ChancelleryDTO>();
            }).CreateMapper();

            return mapper;
        }
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
        #endregion

        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
