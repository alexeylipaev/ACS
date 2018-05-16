using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.BusinessModels
{
    public class OutgoingCorrespondency : BaseCorrespondency
    {

        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable< ExternalOrganizationChancelleryDTO > To { get; set; }


        /// <summary>
        /// От кого"
        /// </summary>
        public EmployeeDTO From { get; set; }
    }
}
