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


    public class ChancelleryService : ServiceBase, IChancelleryService
    {
        public ChancelleryService(IUnitOfWork uow) : base(uow) { }
        /// <summary>
        /// Получить данные о файле по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFile(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id файла ", "");

            var File = Database.FileRecordChancelleries.Find(id);

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
            return mapper.Map<JournalRegistrationsChancellery, JournalRegistrationsChancelleryDTO>(Journal);
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


        public void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
#warning к обсуждению, среди кого искать автора, Учетныйх записией или работников, не увсех работников есть почта, но у всех учеток она есть
            //var Author = Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();
            var AuthorUser= Database.UserManager.FindByEmail(authorEmail); 
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

        #region TypeRecordChancelleries

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
        public void TypeRecordUpdate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            TypeRecordChancellery typeDB = GetMapChancelleryDTOToChancelleryDB().Map<TypeRecordChancelleryDTO, TypeRecordChancellery>(typeDTO);

            var editor = this.Database.UserManager.FindByEmail(currentUserEmail);

            if (editor == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", currentUserEmail);

            if (typeDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", typeDTO.id.ToString());

            try
            {
                Database.TypeRecordChancelleries.Update(typeDB, editor.Id);
               
            }
            catch (Exception e)
            {
                CatchError(e);
            }
        }

        public void TypeRecordMoveToBasket(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            TypeRecordChancellery typeDB = Database.TypeRecordChancelleries.Find(typeDTO.id);

            var editor = this.Database.UserManager.FindByEmail(currentUserEmail);

            if (editor == null)
                throw new ValidationException("Невозможно идентифицировать текущего пользователя по почте", currentUserEmail);

            if (typeDB == null)
                throw new ValidationException("Невозможно редактировать объект с id", typeDTO.id.ToString());

            try
            {
                typeDB.s_EditorId = editor.Id;
                typeDB.s_EditDate = DateTime.Now;
                typeDB.s_InBasket = true;
                Database.TypeRecordChancelleries.Update(typeDB, editor.Id);
               
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
            var mapper = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>().ForMember(c => c.id, c => c.MapFrom(t => t.id));
                cfg.CreateMap<FolderChancelleryDTO, FolderChancellery>().ForMember(c => c.id, c => c.MapFrom(t => t.id));
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancellery>().ForMember(c => c.id, c => c.MapFrom(t => t.id));
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancellery>().ForMember(c => c.id, c => c.MapFrom(t => t.id));
                cfg.CreateMap<FromChancelleryDTO, FromChancellery>();
                cfg.CreateMap<ToChancelleryDTO, ToChancellery>();
                cfg.CreateMap<ChancelleryDTO, Chancellery>().ForMember(x => x.Employee, x => x.MapFrom(c => c.Employee))
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
                cfg.CreateMap<FromChancellery, FromChancelleryDTO>().ForMember(x => x.Employee_Id,
          x => x.MapFrom(m => m.Employee.id));
                cfg.CreateMap<ToChancellery, ToChancelleryDTO>().ForMember(x => x.Chancellery_Id,
          x => x.MapFrom(m => m.Chancellery.id));
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
                cfg.CreateMap<Chancellery, ChancelleryDTO>().ForMember(x => x.Employee,
x => x.MapFrom(m => m.Employee));

            }).CreateMapper();

            return mapper;
        }
        IMapper GetMapTypeRecordChancelleryDBToTypeRecordChancelleryDTO()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chancellery, ChancelleryDTO>().ForMember(x => x.TypeRecordChancellery,
x => x.MapFrom(m => m.TypeRecordChancellery)); ;
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();/*.ForMember(x => x.,
x => x.MapFrom(m => m.Employee.id));*/

            }).CreateMapper();

            return mapper;
        }

        IMapper GetMap_TypeRecordChancellery_DTO_To_DB()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, Chancellery>().ForMember(x => x.TypeRecordChancellery,
x => x.MapFrom(m => m.TypeRecordChancellery)); ;
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>();/*.ForMember(x => x.,
x => x.MapFrom(m => m.Employee.id));*/

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
