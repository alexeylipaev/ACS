using ACS.BLL.DTO;

namespace ACS.BLL.BusinessModels
{
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
