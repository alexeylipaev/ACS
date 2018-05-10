using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    
    public partial class FileRecordChancelleryViewModel : SystemParametersViewModel
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Имя файла")]
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        [Display(Name = "Форма")]
        /// <summary>
        /// Формат
        /// </summary>
        public string Format { get; set; }

        [Display(Name = "Путь к файлу")]
        /// <summary>
        /// Путь к файлу
        /// </summary>

        public string Path { get; set; }
   
    }
}
