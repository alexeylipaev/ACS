using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{

    public interface IChancelleryService
    {

        /// <summary>
        /// Сделать запись
        /// </summary>
        /// <param name="chancelleryDto"></param>
        void MakeChancellery(ChancelleryDTO chancelleryDto, string authorEmail);

        /// <summary>
        /// Получить тип
        /// </summary>
        /// <param name="Id"></param>
        TypeRecordChancelleryDTO GetType(int? Id);


        /// <summary>
        /// Получить все типы
        /// </summary>
        /// <param name="Id"></param>
        IEnumerable<TypeRecordChancelleryDTO> GetAllTypes();

        /// <summary>
        /// Получить файл
        /// </summary>
        /// <param name="Id"></param>
        FileRecordChancelleryDTO GetFile(int? Id);

        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <param name="Id"></param>
        IEnumerable<FileRecordChancelleryDTO> GetAllFiles();

        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="Id"></param>
        UserDTO GetResponsible(int? Id);

        /// <summary>
        /// Получить всех пользователей 
        /// </summary>
        /// <param name="Id"></param>
        IEnumerable<UserDTO> GetAllUser();


        /// <summary>
        /// Получить папку
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FolderChancelleryDTO GetFolder(int? Id);

        /// <summary>
        /// Все все папки
        /// </summary>
        /// <returns></returns>
        IEnumerable<FolderChancelleryDTO> GetAllFolders();

        /// <summary>
        /// Получить журнал регистрации по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        JournalRegistrationsChancelleryDTO GetJournalRegistrations(int? Id);

        /// <summary>
        /// Получить все журналы регистрации 
        /// </summary>
        /// <returns></returns>
        IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations();

        /// <summary>
        /// От кого
        /// </summary>
        /// <returns></returns>
        FromChancelleryDTO GetFromWhom(int? Id);


        /// <summary>
        /// Кому (список)
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToChancelleryDTO> GetToList();

        /// <summary>
        /// Получить канцелярскую запись по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ChancelleryDTO GetChancellery(int? Id);

        /// <summary>
        /// Вся канцелярия
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChancelleryDTO> GetChancelleries();

        void UpdateChancellery(ChancelleryDTO ChancelleryDTO, string authorEmail);

        void Dispose();
    }
}
