using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Кому
    /// </summary>
    public partial class ToChancelleryViewModel : SystemParametersViewModel
    {
        public ToChancelleryViewModel()
        {
            ExternalOrganizations = new HashSet<ExternalOrganizationChancelleryViewModel>();
            Employees = new HashSet<EmployeeViewModel>();
        }

        public int id { get; set; }

        public ICollection<ExternalOrganizationChancelleryViewModel> ExternalOrganizations { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; }

        public virtual int? Chancellery_Id { get; set; }
    }
}
