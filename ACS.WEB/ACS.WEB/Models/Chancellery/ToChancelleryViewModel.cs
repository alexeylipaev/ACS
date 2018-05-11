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
        //public ToChancelleryViewModel()
        //{
        //    ExternalOrganizations = new HashSet<ExternalOrganizationChancelleryViewModel>();
        //    Employees = new HashSet<EmployeeViewModel>();
        //}

        public int id { get; set; }

        public ExternalOrganizationChancelleryViewModel ExternalOrganization { get; set; }
        public EmployeeViewModel Employee { get; set; }

        public ChancelleryViewModel Chancellery { get; set; }
        public override string ToString()
        {
            string result = "";
            if (ExternalOrganization != null) result += ExternalOrganization.Name;
            if (Employee != null) result += Employee.FullName;
            return result;
        }
    }
}
