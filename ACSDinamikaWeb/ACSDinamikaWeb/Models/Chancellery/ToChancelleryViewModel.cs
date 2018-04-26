using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    /// <summary>
    /// Кому
    /// </summary>
    public partial class ToChancelleryViewModel : SystemParametersViewModel
    {
        //public ToChancelleryViewModel()
        //{
        //    ExternalOrganizations = new HashSet<ExternalOrganizationChancelleryViewModel>();
        //    Users = new HashSet<UserViewModel>();
        //}

        public int Id { get; set; }

        //public ICollection<ExternalOrganizationChancelleryViewModel> ExternalOrganizations { get; set; }
        //public ICollection<UserViewModel> Users { get; set; }

        public int? ChancelleryId { get; set; }
        //public virtual ChancelleryViewModel Chancellery { get; set; }
    }
}
