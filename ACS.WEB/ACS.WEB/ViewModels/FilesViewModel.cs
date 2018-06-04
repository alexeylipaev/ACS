using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class FilesViewModel : EntityViewModel
    {
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Формат
        /// </summary>
        public string Extension { get; set; }

        private string _path;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
            }
        }

        /// <summary>
        /// Дата добавления файла (уникальный параметр)
        /// </summary>
        public string DataString { get; private set; }
    }
}