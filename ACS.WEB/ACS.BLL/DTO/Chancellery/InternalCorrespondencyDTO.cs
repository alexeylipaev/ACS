using ACS.BLL.DTO;
using System.Collections.Generic;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Внутреняя
    /// </summary>
    public class InternalCorrespondencyDTO : BaseCorrespondencyDTO
    {
        /// <summary>
        /// От кого
        /// </summary>
        //public EmployeeDTO From { get; set; }
        public int From_EmployeeId { get; set; }
        /// <summary>
        /// Кому
        /// </summary>
        public IEnumerable<int> To_Employees { get; set; }

        //public int From_EmployeeId { get; set; }
    }
}
