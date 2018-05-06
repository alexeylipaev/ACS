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

        public virtual int? Employee_Id { get; set; }

        #endregion

        #region от внешней организации

        // public int? ExternalOrganizationId { get; set; }

        public virtual ExternalOrganizationChancelleryViewModel ExternalOrganization { get; set; }

        #endregion

        //public int? ChancelleryId { get; set; }

        public virtual int? Chancellery_Id { get; set; }
    }
}
