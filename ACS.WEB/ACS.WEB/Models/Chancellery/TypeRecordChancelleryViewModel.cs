using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Тип канцелярской записи
    /// </summary>
    public partial class TypeRecordChancelleryViewModel : SystemParametersViewModel
    {
        //public TypeRecordChancelleryViewModel()
        //{
        //    Chancelleries = new HashSet<ChancelleryViewModel>();
        //}


        public byte id { get; set; }
        [Display(Name = "Тип")]
        public string Name { get; set; }

     
        //public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }
    }
}
