using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{

    /// <summary>
    /// От кого
    /// </summary>
    public partial class FromChancelleryViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        #region от пользователя

        public int? UserId { get; set; }

        public virtual UserViewModel User { get; set; }

        #endregion

        #region от внешней организации

        public int? ExternalOrganizationId { get; set; }

        public virtual ExternalOrganizationChancelleryViewModel ExternalOrganization { get; set; }

        #endregion

        public int? ChancelleryId { get; set; }

        public virtual ChancelleryViewModel Chancellery { get; set; }
    }
}
