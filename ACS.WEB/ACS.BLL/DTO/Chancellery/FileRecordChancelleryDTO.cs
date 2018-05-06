using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    
    public partial class FileRecordChancelleryDTO : SystemParametersDTO
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
