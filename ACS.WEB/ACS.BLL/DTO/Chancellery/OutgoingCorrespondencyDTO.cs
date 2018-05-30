using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.BusinessModels
{
    /// <summary>
    /// Исходящая канцелярия
    /// </summary>
    public class OutgoingCorrespondencyDTO : BaseCorrespondencyDTO
    {
        /// <summary>
        /// От кого"
        /// </summary>
        //public EmployeeDTO From { get; set; }
        public int From_EmployeeId { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<int> To_ExtOrgns { get; set; }

    }
}
