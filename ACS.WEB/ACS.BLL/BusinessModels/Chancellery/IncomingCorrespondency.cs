using ACS.BLL.DTO;

namespace ACS.BLL.BusinessModels
{
    /// <summary>
    /// Входящая канцелярия
    /// </summary>
    public class IncomingCorrespondency : BaseCorrespondency
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public ExternalOrganizationChancelleryDTO From { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        public EmployeeDTO To { get; set; }
    }
}
