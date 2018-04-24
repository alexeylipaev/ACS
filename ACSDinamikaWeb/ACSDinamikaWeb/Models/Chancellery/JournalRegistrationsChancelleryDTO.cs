using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
 
    public partial class JournalRegistrationsChancelleryViewModel : SystemParametersViewModel
    {

        public JournalRegistrationsChancelleryViewModel()
        {
            Chancelleries = new HashSet<ChancelleryViewModel>();
        }

        public int Id { get; set; }

       
        public string Name { get; set; }


        public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

    }
}
