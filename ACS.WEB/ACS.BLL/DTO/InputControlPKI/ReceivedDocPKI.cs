﻿using ACS.BLL.DTO;
using System;

namespace ACS.DAL.Entities
{
    public class ReceivedDocPKIDTO : SystemParametersDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ПО
        /// </summary>
        public bool IsSoftware { get; set; }

        /// <summary>
        /// наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Место хранения
        /// </summary>
        public string StorageLocation { get; set; }

        /// <summary>
        /// Количество дефекта
        /// </summary>
        public int AmountDefect { get; set; }


        /// <summary>
        /// Проверено ОТК
        /// </summary>
        public bool CheckOTK { get; set; }

        /// <summary>
        /// Дата проверки
        /// </summary>
        public DateTime? DateOfReview { get; set; }

        /// <summary>
        /// Отправлено
        /// </summary>
        public bool IsSent { get; set; }


        /// <summary>
        /// Кому передано
        /// </summary>
        public virtual EmployeeDTO GotEmpl { get; set; }

        /// <summary>
        /// Кто проверил
        /// </summary>
        public virtual EmployeeDTO CheckedByWhom { get; set; }

        /// <summary>
        /// Покупное изделие
        /// </summary>
        public virtual InputControlPKIDTO PKI { get; set; }

    }
}