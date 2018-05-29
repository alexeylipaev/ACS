using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACS.BLL.Interfaces
{
    public interface IChancelleryService : IDisposable
    {
      
        Task<int> DeleteAsync(int id);
        Task<ChancelleryDTO> FindAsync(int id);
        Task<IncomingCorrespondencyDTO> FindIncomingAsync(int id);
        Task<OutgoingCorrespondencyDTO> FindOutgoingAsync(int id);
        Task<InternalCorrespondencyDTO> FindInternalAsync(int id);
        Task<IEnumerable<ChancelleryDTO>> GetAllAsync();

        /// <summary>
        /// Получить канцелярские записи по модели поиска
        /// </summary>
        /// <param name="сhancellerySearchModel"></param>
        /// <returns></returns>
        IEnumerable<Chancellery> GetAllOnSearch(ChancellerySearchModel searchModel);

        IEnumerable<Chancellery> GetOutgoingAllOnSearch(ChancellerySearchModel searchModel);

        IEnumerable<Chancellery> GetInternalAllOnSearch(ChancellerySearchModel searchModel);

        IEnumerable<Chancellery> GetIncomingAllOnSearch(ChancellerySearchModel searchModel);

        #region Incoming 

        /// <summary>
        /// Получить канцелярские записи по модели поиска
        /// </summary>
        /// <param name="сhancellerySearchModel"></param>
        /// <returns></returns>
        Task<IEnumerable<IncomingCorrespondencyDTO>> ChancelleryGetAllIncomingAsync(ChancellerySearchModel searchModel);

        Task<int> ChancelleryCreateOrUpdateIncomingAsync(IncomingCorrespondencyDTO incomingCorrespondencyDto, string authorEmail);

        #endregion

        #region OutGoing
        Task<int> ChancelleryCreateOrUpdateOutgoingAsync(OutgoingCorrespondencyDTO outgoingCorrespondencyDto, string authorEmail);


        /// <summary>
        /// Получить канцелярские записи по модели поиска
        /// </summary>
        /// <param name="сhancellerySearchModel"></param>
        /// <returns></returns>
        Task<IEnumerable<OutgoingCorrespondencyDTO>> ChancelleryGetAllOutgoingAsync(ChancellerySearchModel searchModel);

        #endregion

        #region Internal

        /// <summary>
        /// Получить канцелярские записи по модели поиска
        /// </summary>
        /// <param name="сhancellerySearchModel"></param>
        /// <returns></returns>
        Task<IEnumerable<InternalCorrespondencyDTO>> ChancelleryGetAllInternalAsync(ChancellerySearchModel searchModel);

        Task<int> ChancelleryCreateOrUpdateInternalAsync(InternalCorrespondencyDTO internalCorrespondencyDto, string authorEmail);

        #endregion

        #region Folder

        /// <summary>
        /// Получить папку
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FolderCorrespondencesDTO> FindFolderAsync(int id);

        /// <summary>
        /// Все все папки
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FolderCorrespondencesDTO>> GetAllFolders();

        #endregion

        #region Журнал регистраций

        /// <summary>
        /// Получить журнал регистрации по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JournalRegistrationsCorrespondencesDTO> FindJournalAsync(int id);

        /// <summary>
        /// Получить все журналы регистрации 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<JournalRegistrationsCorrespondencesDTO>> GetAllJournalesRegistrationsAsync();

        #endregion

        #region Внешнии организации

        /// <summary>
        /// Получить внешнюю организацию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExternalOrganizationDTO> FindExtlOrgAsync(int id);


        /// <summary>
        /// Получить все внешнии организации
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExternalOrganizationDTO>> GetAllExternalOrganizationsAsync();

        #endregion

        #region работа с файлами 

       int AttachFiles(IEnumerable<HttpPostedFileBase> files, int ChancelleryId, string authorEmail);

        IEnumerable<FilesDTO> AttachFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases, string authorEmail);


        /// <summary>
        /// Прикрепить/Открепить файл
        /// </summary>
        /// <param name="files"></param>
        /// <param name="EditorId"></param>
        /// <returns></returns>
        int AttachOrDetachFile(FilesDTO fileDTO, string authorEmail, int ChancelleryId, bool attach);

        /// <summary>
        /// Прикрепить/Открепить файлы
        /// </summary>
        /// <param name="id"></param>
        int AttachOrDetachFiles(IEnumerable<FilesDTO> filesDto, string authorEmail, int ChancelleryId, bool attach);

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="id"></param>
        int DeletedFile(FilesDTO fileDTO);

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="id"></param>
        int DeletedFiles(IEnumerable<FilesDTO> files);

        /// <summary>
        /// Получить связанный с канцелярией файл по его пути
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ChancelleryId"></param>
        /// <returns></returns>
        Task<FilesDTO> GetFileChancellerByPathAsync(string Path, int ChancelleryId);

        /// <summary>
        /// Получить все файлы канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        Task<IEnumerable<FilesDTO>> GetAllFilesChancelleryAsync(CorrespondencesBaseDTO CorrespondencesDTO);

        /// <summary>
        /// Получить файл по его ID
        /// </summary>
        /// <param name="FileId"></param>
        /// <returns></returns>
        Task<FilesDTO> FindFileAsync(int FileId);
       


        #endregion

        #region Employee
        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="id"></param>
        Task<EmployeeDTO> FindEmplAsync(int id);

        /// <summary>
        /// Получить всех пользователей 
        /// </summary>
        /// <param name="id"></param>
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();


        /// <summary>
        /// Получить все файлы канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        Task<IEnumerable<EmployeeDTO>> GetAllResponsiblesChancelleryAsync(CorrespondencesBaseDTO CorrespondencesDTO);

        #endregion

        #region Работа с типами корреспонденции

        /// <summary>
        /// Получить все типы
        /// </summary>
        /// <param name="id"></param>
        Task<IEnumerable<TypeRecordCorrespondencesDTO>> GetAllTypesChancelleryAsync();

        /// <summary>
        /// Получить тип по id
        /// </summary>
        /// <param name="id"></param>
        Task<TypeRecordCorrespondencesDTO> FindTypeChancelleryAsync(int id);


        /// <summary>
        /// Создать новый тип корреспонденции
        /// </summary>
        /// <param name="typeDTO"></param>
        /// <param name="currentUserEmail"></param>
        Task<int> CreateOrUpdate_TypeChancellery(TypeRecordCorrespondencesDTO typeDTO, string authorEmail);


        /// <summary>
        /// Удалить тип корреспонденции
        /// </summary>
        /// <param name="typeId"></param>
        Task<int> DeleteTypeChancellery(int typeId);

        #endregion
    }
}
