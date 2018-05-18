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
using System.Linq.Expressions;
using System.Web;
using ACS.BLL.BusinessModels.Chancellery;

namespace ACS.BLL.Services
{

    public class ChancelleryService : ServiceBase, IChancelleryService
    {
        private ExternalOrganizationChancelleryService ExternalOrganizationChancelleryService;
        private EmployeeService EmployeeService;
        private JournalRegistrationsChancelleryService JournalRegistrationsChancelleryService;
        private FolderChancelleryService FolderChancelleryService;
        private TypeRecordChancelleryService TypeRecordChancelleryService;
        private FileRecordChancelleryService FileRecordChancelleryService;
        public ChancelleryService(IUnitOfWork uow) : base(uow)
        {
            ExternalOrganizationChancelleryService = new ExternalOrganizationChancelleryService(uow);
            EmployeeService = new EmployeeService(uow);
            JournalRegistrationsChancelleryService = new JournalRegistrationsChancelleryService(uow);
            FolderChancelleryService = new FolderChancelleryService(uow);
            TypeRecordChancelleryService = new TypeRecordChancelleryService(uow);
            FileRecordChancelleryService = new FileRecordChancelleryService(uow);
        }

        #region Канцелярия 

        int CreateOrUpdate_To(ToChancelleryDTO DTO_to, int AuthorID)
        {
            try
            {
                ToChancellery To_Original = Database.ToChancelleries.Find(DTO_to.id);

                var to = MapDALBLL.GetMapp().Map(DTO_to, To_Original);

                if (To_Original != null)
                {
                    To_Original.Chancellery = to.Chancellery;
                    To_Original.Employee = to.Employee;
                    To_Original.ExternalOrganization = to.ExternalOrganization;
                    To_Original.s_InBasket = to.s_InBasket;

                    return Database.ToChancelleries.Update(To_Original, AuthorID);
                }
                else if (To_Original == null)
                {
                    return Database.ToChancelleries.Add(to, AuthorID);
                }

            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        int CreateOrUpdate_From(FromChancelleryDTO DTO_From, int AuthorID)
        {
            try
            {
                FromChancellery From_Original = Database.FromChancelleries.Find(DTO_From.id);

                var from = MapDALBLL.GetMapp().Map(DTO_From, From_Original);

                if (From_Original != null)
                {
                    From_Original.Chancellery = from.Chancellery;
                    From_Original.Employee = from.Employee;
                    From_Original.ExternalOrganization = from.ExternalOrganization;
                    From_Original.s_InBasket = from.s_InBasket;

                    return Database.FromChancelleries.Update(From_Original, AuthorID);
                }
                else if (From_Original == null)
                {
                    return Database.FromChancelleries.Add(from, AuthorID);
                }

            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        void CraeateOrUpdate_FromAndTo(ChancelleryDTO chancelleryDTO, int AuthorID)
        {
            int amountChanged_To = 0;
            foreach (var DTO_to in chancelleryDTO.ToChancelleries)
            {
                amountChanged_To += CreateOrUpdate_To(DTO_to, AuthorID);
            }
            int amountChanged_From = 0;
            foreach (var DTO_From in chancelleryDTO.FromChancelleries)
            {
                amountChanged_From += CreateOrUpdate_From(DTO_From, AuthorID);
            }
        }


        public int CreateOrUpdateChancellery(ChancelleryDTO chancelleryDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var chancelleryOriginal = Database.Chancelleries.Find(chancelleryDTO.id);
                /*   var chanceller =*/

                var chancellery = MapDALBLL.GetMapForUpdateOrCreate().Map(chancelleryDTO, chancelleryOriginal);

                if (chancelleryOriginal != null)
                {
                    //CraeateOrUpdate_FromAndTo(chancellery, AuthorID);
                    return Database.Chancelleries.Update(chancelleryOriginal, AuthorID);
                }

                else if (chancelleryOriginal == null)
                {
                    //CraeateOrUpdate_FromAndTo(chancelleryDTO, AuthorID);
                    return Database.Chancelleries.Add(chancellery, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
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
            return MapDALBLL.GetMapp().Map<Chancellery, ChancelleryDTO>(Chancellery);
        }



        #region Входящая канцелярия


        public IEnumerable<IncomingCorrespondency> ChancelleryGetIncoming(ChancellerySearchModel сhancellerySearchModel)
        {
            var chancellerieDTOs = ChancelleryGet(сhancellerySearchModel);
            return MapDALBLL.GetMap_Incoming_DTO_TO_DB().Map<IEnumerable<ChancelleryDTO>, IEnumerable<IncomingCorrespondency>>(chancellerieDTOs);
        }

        public int ChancelleryCreateIncoming(IncomingCorrespondency incomingCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            ChancelleryDTO newDTO = MapDALBLL.GetMap_IncomingDB_TO_DTO().Map<IncomingCorrespondency, ChancelleryDTO>(incomingCorrespondency);
            newDTO.TypeRecordChancellery = TypeRecordGet(Constants.CorrespondencyType.Incoming);

            //var newDB = MapDALBLL.GetMapForUpdateOrCreate().Map<ChancelleryDTO, Chancellery>(newDTO);

         return   CreateOrUpdateChancellery(newDTO, editorEmail);
            //return 1;
        }
       


        public int ChancelleryUpdateIncoming(IncomingCorrespondency incomingCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            var original = Database.Chancelleries.Find(incomingCorrespondency.id);

            MapDALBLL.GetMap_Incoming_DTO_TO_DB().Map(original, incomingCorrespondency);
            Database.Chancelleries.Update(original, authorID);
            return 1;
        }


        #endregion

        #region Исходящая канцелярия 

        public int ChancelleryCreateOutgoing(OutgoingCorrespondency outgoingCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            ChancelleryDTO newDTO = MapDALBLL.GetMap_OutgoingDB_TO_DTO().Map<OutgoingCorrespondency, ChancelleryDTO>(outgoingCorrespondency);
            newDTO.TypeRecordChancellery = TypeRecordGet(Constants.CorrespondencyType.Incoming);

            var newDB = MapDALBLL.GetMapForUpdateOrCreate().Map<ChancelleryDTO, Chancellery>(newDTO);

            Database.Chancelleries.Add(newDB, authorID);
            return 1;
        }

        public int ChancelleryUpdateOutgoing(OutgoingCorrespondency outgoingCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            var original = Database.Chancelleries.Find(outgoingCorrespondency.id);

            MapDALBLL.GetMap_Outgoing_DTO_TO_DB().Map(original, outgoingCorrespondency);
            Database.Chancelleries.Update(original, authorID);
            return 1;
        }

        public IEnumerable<OutgoingCorrespondency> ChancelleryGetOutgoing(ChancellerySearchModel сhancellerySearchModel)
        {
            var chancellerieDTOs = ChancelleryGet(сhancellerySearchModel);
            return MapDALBLL.GetMap_Outgoing_DTO_TO_DB().Map<IEnumerable<ChancelleryDTO>, IEnumerable<OutgoingCorrespondency>>(chancellerieDTOs);
        }


        #endregion

        #region внутреняя канцелярия

        public IEnumerable<InternalCorrespondency> ChancelleryGetInternal(ChancellerySearchModel сhancellerySearchModel)
        {
            var chancellerieDTOs = ChancelleryGet(сhancellerySearchModel);
            return MapDALBLL.GetMap_Internal_DTO_TO_DB().Map<IEnumerable<ChancelleryDTO>, IEnumerable<InternalCorrespondency>>(chancellerieDTOs);
        }

 

        public int ChancelleryCreateInternal(InternalCorrespondency internalCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            ChancelleryDTO newDTO = MapDALBLL.GetMap_InternalDB_TO_DTO().Map<InternalCorrespondency, ChancelleryDTO>(internalCorrespondency);
            newDTO.TypeRecordChancellery = TypeRecordGet(Constants.CorrespondencyType.Incoming);

            var newDB = MapDALBLL.GetMapForUpdateOrCreate().Map<ChancelleryDTO, Chancellery>(newDTO);

            Database.Chancelleries.Add(newDB, authorID);
            return 1;
        }

        public int ChancelleryUpdateInternal(InternalCorrespondency internalCorrespondency, string editorEmail)
        {
            int authorID = 0;
            try { authorID = CheckAuthorAndGetIndexAuthor(editorEmail); }
            catch (Exception ex) { throw ex; }

            var original = Database.Chancelleries.Find(internalCorrespondency.id);

            MapDALBLL.GetMap_Internal_DTO_TO_DB().Map(original, internalCorrespondency);
            Database.Chancelleries.Update(original, authorID);
            return 1;
        }


        #endregion


        public IEnumerable<ChancelleryDTO> ChancelleryGet(ChancellerySearchModel сhancellerySearchModel)
        {

            Func<Chancellery, Boolean> predicate = delegate (Chancellery c)

            {
                bool boolResult = false;
                if (сhancellerySearchModel != null)
                {
                    if (сhancellerySearchModel.Id.HasValue)
                        boolResult = (c.id == сhancellerySearchModel.Id);
#warning необходимо доработать фильтр
                    //if (!string.IsNullOrEmpty(сhancellerySearchModel.FromContains))
                    //    throw new NotImplementedException("");
                    if (сhancellerySearchModel.RegistryDateFrom.HasValue)
                        boolResult = c.DateRegistration >= сhancellerySearchModel.RegistryDateFrom;
                    if (сhancellerySearchModel.RegistryDateTo.HasValue)
                        boolResult = c.DateRegistration <= сhancellerySearchModel.RegistryDateTo;

                }
                return boolResult;
            };
            //Expression<Func<Chancellery, bool>> expr = mc => predicate(mc);
            var result = Database.Chancelleries.Find(predicate);
            return MapDALBLL.GetMapp().Map<IEnumerable<Chancellery>, IEnumerable<ChancelleryDTO>>(result);
        }

        /// <summary>
        /// Получить всю канцелярию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ChancelleryDTO> ChancellerieGetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(Database.Chancelleries.GetAll().ToList());
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
        /// Тип канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeRecordChancelleryDTO TypeRecordGet(Constants.CorrespondencyType сorrespondencyType)
        {
            int id = (int)сorrespondencyType;
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
            return MapDALBLL.GetMapp().Map<IEnumerable<ToChancellery>, List<ToChancelleryDTO>>(Database.ToChancelleries.GetAll());
        }

        #endregion

        #endregion

        #region работа с файлами 

        public IEnumerable<FileRecordChancelleryDTO> AttachFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases)
        {
            return FileRecordChancelleryService.AddFiles(httpPostedFileBases);
        }

        /// <summary>
        /// Получить данные о файле по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFile(int FileId)
        {
            return FileRecordChancelleryService.GetFileRecord(FileId);
        }

        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileRecordChancelleryDTO> GetAllFiles()
        {
            return FileRecordChancelleryService.GetFilesRecordChancellery();
        }


        /// <summary>
        /// Получить связанный с канцелярией файл по его пути
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public FileRecordChancelleryDTO GetFileChancellerByPath(string Path, int ChancelleryId)
        {
            return FileRecordChancelleryService.GetFileChancellerByPath(Path, ChancelleryId);
        }


        public IEnumerable<FileRecordChancelleryDTO> GetAllFilesChancellery(ChancelleryDTO Chancellery)
        {
            return FileRecordChancelleryService.GetAllFilesChancellery(Chancellery);
        }

        public int AttachFiles(IEnumerable<HttpPostedFileBase> files, int ChancelleryId, string authorEmail)
        {
            foreach (var file in files)
            {
                if (file != null)
                {

                    string pathForSave = BusinessModels.Chancellery.Constants.FolderPath;

                    //Возвращает имя файла указанной строки пути без расширения.
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //fileVM.Name = fileName;

                    //Возвращает расширение указанной строки пути.
                    string extension = Path.GetExtension(file.FileName);

                    //fileVM.Format = extension;

                    //fileVM.Path = @"X:/Подразделения/СВиССА/Файлы канцелярии/" + fileName;
                    string path = Path.Combine(pathForSave, fileName + extension);

                    FileRecordChancelleryDTO fileDTO = null;/* = this.GetFileChancellerByPath(path, ChancelleryId);*/

                    if (fileDTO == null)
                    {
                        fileDTO = new FileRecordChancelleryDTO();
                        fileDTO.Name = fileName;
                        fileDTO.Path = path;
                        fileDTO.Format = extension;
                        fileDTO.DataString = DateTime.Now.ToString("ddMMyyyyhhmmssfff");

                    }

                    path = Path.Combine(pathForSave, fileDTO.Name + fileDTO.DataString + extension);

                    file.SaveAs(path);
                    return this.AttachOrDetachFile(fileDTO, authorEmail, ChancelleryId, true);
                }
            }
            return 0;
        }

        public int AttachOrDetachFile(FileRecordChancelleryDTO fileDTO, string authorEmail, int ChancelleryId, bool attach)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            FileRecordChancellery file = Database.FileRecordChancelleries.Find(fileDTO.id);

            if (file == null)//файла нет, создать нужно
            {
                FileRecordChancellery newFile = MapDALBLL.GetMapp().Map<FileRecordChancelleryDTO, FileRecordChancellery>(fileDTO);

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
                    else
                    {
                        file.Name += "_dtch";
                        file.s_InBasket = true;// открепить
                    }

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

        public void Dispose()
        {
            Database.Dispose();
            ExternalOrganizationChancelleryService.Dispose();
            EmployeeService.Dispose();
            JournalRegistrationsChancelleryService.Dispose();
            FolderChancelleryService.Dispose();
            TypeRecordChancelleryService.Dispose();
            FileRecordChancelleryService.Dispose();
        }


    }
}
