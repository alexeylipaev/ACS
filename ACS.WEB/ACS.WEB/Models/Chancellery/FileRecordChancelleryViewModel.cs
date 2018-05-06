﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    
    public partial class FileRecordChancelleryViewModel : SystemParametersViewModel
    {
        public int id { get; set; }

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
  
        public string Path { get; set; }
   
    }
}
