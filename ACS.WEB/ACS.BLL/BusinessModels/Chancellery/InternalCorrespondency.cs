using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.BusinessModels
{
    /// <summary>
    /// Внутреняя
    /// </summary>
    public class InternalCorrespondency : BaseCorrespondency
    {
        /// <summary>
        /// От кого
        /// </summary>
        public EmployeeDTO From { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<EmployeeDTO> To { get; set; }
    }
}
