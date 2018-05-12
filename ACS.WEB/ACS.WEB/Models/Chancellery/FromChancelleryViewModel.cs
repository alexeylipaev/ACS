using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{

    /// <summary>
    /// От кого
    /// </summary>
    public partial class FromChancelleryViewModel : SystemParametersViewModel
    {
        public int id { get; set; }

        #region от пользователя

        //public int? EmployeeId { get; set; }

        public EmployeeViewModel Employee { get; set; }

        #endregion

        #region от внешней организации

        // public int? ExternalOrganizationId { get; set; }

        public virtual ExternalOrganizationChancelleryViewModel ExternalOrganization { get; set; }

        #endregion

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
