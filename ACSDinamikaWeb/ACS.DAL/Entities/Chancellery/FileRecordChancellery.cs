﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Файл
    /// </summary>
    public partial class FileRecordChancellery : SystemParameters
    {

        public int Id { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Формат
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Required]
        public string Path { get; set; }


    }
}
