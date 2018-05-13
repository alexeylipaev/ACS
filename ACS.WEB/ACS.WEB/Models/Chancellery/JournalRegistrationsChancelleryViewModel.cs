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

        public JournalRegistrationsChancelleryViewModel()
        {
            Chancelleries = new HashSet<ChancelleryViewModel>();
        }
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Журнал регистрации")]
        public string Name { get; set; }

        [Display(Name = "Канцелярия в журнале")]
        public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

    }

    public class SelectedJournalRegChancellery
    {
        public int Id { get; set; }

        public int SelectedId { get; set; }
    }

}
