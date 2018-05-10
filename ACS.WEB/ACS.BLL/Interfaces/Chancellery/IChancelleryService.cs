using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{

    public interface IChancelleryService : IDisposable 
    {

        #region работа с файлами 

        /// <summary>
        /// Добавить файл
        /// </summary>
        /// <param name="files"></param>
        /// <param name="EditorId"></param>
        /// <returns></returns>
        int AttachmentFile(FileRecordChancelleryDTO file, int EditorId);

        /// <summary>
        /// Добавить файлы
        /// </summary>
        /// <param name="id"></param>
        int AttachmentFiles(IEnumerable<FileRecordChancelleryDTO> files, int EditorId);


        /// <summary>
        /// Открепить файл
        /// </summary>
        /// <param name="id"></param>
        int DetachFile(FileRecordChancelleryDTO fileRecordChancelleryDTO);


        /// <summary>
        /// Открепить файлы
        /// </summary>
        /// <param name="id"></param>
        int DetachFiles(IEnumerable<FileRecordChancelleryDTO> files);

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
        /// Получить файл
        /// </summary>
        /// <param name="id"></param>
        FileRecordChancelleryDTO GetFile(int id);

        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<FileRecordChancelleryDTO> GetAllFiles(int id);

        /// <summary>
        /// Получить все файлы
        /// </summary>
        IEnumerable<FileRecordChancelleryDTO> GetAllFiles();

        #endregion

        /// <summary>
        /// Сделать запись
        /// </summary>
        /// <param name="chancelleryDto"></param>
        void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail);



        int DeleteChancellery(int chancelleryId);

        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="id"></param>
        EmployeeDTO GetResponsible(int id);

        /// <summary>
        /// Получить всех пользователей 
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<EmployeeDTO> GetAllUser();


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

        /// <summary>
        /// От кого
        /// </summary>
        /// <returns></returns>
        FromChancelleryDTO GetFromWhom(int id);


        /// <summary>
        /// Кому (список)
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToChancelleryDTO> GetToList();

        /// <summary>
        /// Получить канцелярскую запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ChancelleryDTO ChancelleryGet(int id);

        /// <summary>
        /// Вся канцелярия
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChancelleryDTO> ChancellerieGetAll();

        void ChancelleryUpdate(ChancelleryDTO ChancelleryDTO, string authorEmail);

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
        /// Создать новый тип корреспонденции
        /// </summary>
        /// <param name="typeDTO"></param>
        /// <param name="currentUserEmail"></param>
        void TypeRecordCreate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail);

        /// <summary>
        /// Обновить тип корреспонденции
        /// </summary>
        /// <param name="typeDTO"></param>
        /// <param name="currentUserEmail"></param>
        void TypeRecordUpdate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail);

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
