using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderChancelleryViewModel : SystemParametersViewModel
    {

        public FolderChancelleryViewModel()
        {
            Chancelleries = new HashSet<ChancelleryViewModel>();
        }
        [Display(Name = "ID")]
        public int id { get; set; }


        [Display(Name = "Папка")]
        public string Name { get; set; }

        [Display(Name = " Канцелярские записи в папке")]
        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }
    }
}
