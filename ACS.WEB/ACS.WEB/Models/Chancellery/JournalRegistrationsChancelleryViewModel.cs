using System;
using System.Collections.Generic;

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

       
        public string Name { get; set; }


        //public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

    }
}
