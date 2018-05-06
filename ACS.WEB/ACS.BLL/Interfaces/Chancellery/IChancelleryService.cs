﻿using ACS.BLL.DTO;
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

        /// <summary>
        /// Сделать запись
        /// </summary>
        /// <param name="chancelleryDto"></param>
        void MakeChancellery(ChancelleryDTO chancelleryDto, string authorEmail);

        /// <summary>
        /// Получить тип
        /// </summary>
        /// <param name="id"></param>
        TypeRecordChancelleryDTO GetType(int? id);


        /// <summary>
        /// Получить все типы
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<TypeRecordChancelleryDTO> GetAllTypes();

        /// <summary>
        /// Получить файл
        /// </summary>
        /// <param name="id"></param>
        FileRecordChancelleryDTO GetFile(int? id);

        /// <summary>
        /// Получить все файлы
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<FileRecordChancelleryDTO> GetAllFiles();

        /// <summary>
        /// Получить ответственного
        /// </summary>
        /// <param name="id"></param>
        EmployeeDTO GetResponsible(int? id);

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
        FolderChancelleryDTO GetFolder(int? id);

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
        JournalRegistrationsChancelleryDTO GetJournalRegistrations(int? id);

        /// <summary>
        /// Получить все журналы регистрации 
        /// </summary>
        /// <returns></returns>
        IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations();

        /// <summary>
        /// От кого
        /// </summary>
        /// <returns></returns>
        FromChancelleryDTO GetFromWhom(int? id);


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
        ChancelleryDTO GetChancellery(int? id);

        /// <summary>
        /// Вся канцелярия
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChancelleryDTO> GetChancelleries();

        void UpdateChancellery(ChancelleryDTO ChancelleryDTO, string authorEmail);


    }
}
