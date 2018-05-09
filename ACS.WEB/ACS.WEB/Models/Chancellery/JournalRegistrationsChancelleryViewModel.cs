using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Журнал канцелярский
    /// </summary>
    public partial class JournalRegistrationsChancelleryViewModel : SystemParametersViewModel
    {

        //public JournalRegistrationsChancelleryViewModel()
        //{
        //    Chancelleries = new HashSet<ChancelleryViewModel>();
        //}

        public int id { get; set; }

        [Display(Name = "Журнал регистрации")]
        public string Name { get; set; }


        //public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

    }
}
