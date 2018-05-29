using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class FolderChancelleryViewModel : EntityViewModel
    {
        [Display(Name = "Папка")]
        public string Name { get; set; }

        [Display(Name = " Канцелярские записи в папке")]
        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public string Chancelleries { get; set; }

        public override string ToString()
        {

            return this.Name ?? "";
        }
    }
}