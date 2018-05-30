using ACS.BLL.DTO;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Входящая канцелярия
    /// </summary>
    public class IncomingCorrespondencyDTO : BaseCorrespondencyDTO
    {
        /// <summary>
        /// От кого"
        /// </summary>
        //public ExternalOrganizationChancelleryDTO From { get; set; }
        public int From_ExternalOrganizationChancelleryId { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        //public EmployeeDTO To { get; set; }
        public int To_EmployeeId { get; set; }
    }
}
