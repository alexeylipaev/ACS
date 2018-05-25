

using System.ComponentModel.DataAnnotations;

namespace ACS.WEB.ViewModel
{
    public class IncomingCorrespondencyViewModel : BaseCorrespondencyViewModel
    {

        public IncomingCorrespondencyViewModel() :base()
        {
            this.TypeRecordChancelleryId = (int)ACS.BLL.BusinessModels.Chancellery.Constants.CorrespondencyType.Incoming;
        }
        /// <summary>
        /// От кого"
        /// </summary>
        [Display(Name = "От кого")]
        public ExternalOrganizationChancelleryViewModel From { get; set; }
        [Display(Name = "От кого")]
        public override string FromStringValue {
            get {
                if (From == null) return string.Empty;
                else return this.From.Name;
            }
        }

        /// <summary>
        /// Кому
        /// </summary>
        [Display(Name = "Кому")]
        public EmployeeViewModel To { get; set; }

        [Display(Name = "Кому")]
        public override string ToStringValue
        {
            get
            {
                if (To == null) return string.Empty;
                else return this.To.FullName;
            }
        }
    }
}
