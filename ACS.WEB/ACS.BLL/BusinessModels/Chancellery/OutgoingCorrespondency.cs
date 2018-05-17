using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.BusinessModels
{
    /// <summary>
    /// Исходящая канцелярия
    /// </summary>
    public class OutgoingCorrespondency : BaseCorrespondency
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public EmployeeDTO From { get; set; }
        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<ExternalOrganizationChancelleryDTO> To { get; set; }

    }
}
