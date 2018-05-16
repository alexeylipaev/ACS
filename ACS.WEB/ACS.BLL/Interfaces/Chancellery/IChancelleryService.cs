using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
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

        #region Канцелярия

        /// <summary>
        /// Получить канцелярскую запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ChancelleryDTO ChancelleryGet(int id);

        /// <summary>
        /// Получить канцелярские записи по модели поиска
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ChancelleryDTO> ChancelleryGet(ChancellerySearchModel сhancellerySearchModel);
        
        ///// <summary>
        ///// Сделать запись
        ///// </summary>
        ///// <param name="chancelleryDto"></param>
        //void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail);

        int DeleteChancellery(int chancelleryId);

        /// <summary>
        /// Вся канцелярия
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChancelleryDTO> ChancellerieGetAll();

        int CreateOrUpdateChancellery(ChancelleryDTO ChancelleryDTO, string authorEmail);

        #region Folder

        /// <summary>
        /// Получить папку
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FolderChancelleryDTO FolderGet(int id);

        /// <summary>
        /// Все все папки
        /// </summary>
        /// <returns></returns>
        IEnumerable<FolderChancelleryDTO> GetAllFolders();
        #endregion

        #region Журнал регистраций

        /// <summary>
        /// Получить журнал регистрации по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JournalRegistrationsChancelleryDTO GetJournalRegistrations(int id);

        /// <summary>
        /// Получить все журналы регистрации 
        /// </summary>
        /// <returns></returns>
        IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations();

        #endregion


        #region Внешнии организации

        /// <summary>
        /// Получить внешнюю организацию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExternalOrganizationChancelleryDTO GetExternalOrganization(int id);

        /// <summary>
        /// Получить все внешнии организации
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExternalOrganizationChancelleryDTO> GetAllExternalOrganizations();

        #endregion

        #region От кого

        /// <summary>
        /// От кого
        /// </summary>
        /// <returns></returns>
        FromChancelleryDTO GetFromWhom(int id);

        #endregion

        #region Кому

        /// <summary>
        /// Кому (список)
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToChancelleryDTO> GetToList();

        #endregion

        #endregion

        #region работа с файлами 

        int AttachFiles(IEnumerable<HttpPostedFileBase> files, int ChancelleryId, string authorEmail);

        /// <summary>
        /// Прикрепить/Открепить файл
        /// </summary>
        /// <param name="files"></param>
        /// <param name="EditorId"></param>
        /// <returns></returns>
        int AttachOrDetachFile(FileRecordChancelleryDTO fileDTO, string authorEmail, int ChancelleryId, bool attach);

        /// <summary>
        /// Прикрепить/Открепить файлы
        /// </summary>
        /// <param name="id"></param>
        int AttachOrDetachFiles(IEnumerable<FileRecordChancelleryDTO> files, string authorEmail, int ChancelleryId, bool attach);


        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="id"></param>
        int DeletedFile(FileRecordChancelleryDTO fileRecordChancelleryDTO);

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="id"></param>
        int DeletedFiles(IEnumerable<FileRecordChancelleryDTO> files);

        /// <summary>
        /// Получить связанный с канцелярией файл по его пути
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ChancelleryId"></param>
        /// <returns></returns>
        FileRecordChancelleryDTO GetFileChancellerByPath(string Path, int ChancelleryId);

        /// <summary>
        /// Получить связанный с канцелярской записью файл по его id
        /// </summary>
        /// <param name="id"></param>
        FileRecordChancelleryDTO GetFileChanceller(int FileId);

        /// <summary>
        /// Получить все файлы канцелярской записи
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<FileRecordChancelleryDTO> GetAllFilesChancellery(ChancelleryDTO Chancellery);

        /// <summary>
        /// Получить файл по его ID
        /// </summary>
        /// <param name="FileId"></param>
        /// <returns></returns>
        FileRecordChancelleryDTO GetFile(int FileId);

        /// <summary>
        /// Получить все файлы
        /// </summary>
        IEnumerable<FileRecordChancelleryDTO> GetAllFiles();

        #endregion

        #region Employee
        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="id"></param>
        EmployeeDTO GetEmployee(int id);

        /// <summary>
        /// Получить всех пользователей 
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<EmployeeDTO> GetEmployees();

        #endregion


        #region Работа с типами корреспонденции

        /// <summary>
        /// Получить все типы
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<TypeRecordChancelleryDTO> TypeRecordGetAll();

        /// <summary>
        /// Получить тип по id
        /// </summary>
        /// <param name="id"></param>
        TypeRecordChancelleryDTO TypeRecordGetById(int id);

        /// <summary>
        /// Получить тип по id
        /// </summary>
        /// <param name="id"></param>
        TypeRecordChancelleryDTO TypeRecordGetByName(string typeName);

        /// <summary>
        /// Создать новый тип корреспонденции
        /// </summary>
        /// <param name="typeDTO"></param>
        /// <param name="currentUserEmail"></param>
        void TypeRecordCreateOrUpdate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail);


        /// <summary>
        /// Обновить тип корреспонденции
        /// </summary>
        /// <param name="typeDTO"></param>
        /// <param name="currentUserEmail"></param>
        void TypeRecordMoveToBasket(TypeRecordChancelleryDTO typeDTO, string currentUserEmail);

        /// <summary>
        /// Удалить тип корреспонденции
        /// </summary>
        /// <param name="typeId"></param>
        void TypeRecordDelete(int typeId);

        #endregion
    }
}
