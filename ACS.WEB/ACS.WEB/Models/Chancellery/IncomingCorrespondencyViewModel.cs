

namespace ACS.WEB.ViewModel
{
    public class IncomingCorrespondencyViewModel : BaseCorrespondencyViewModel
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public ExternalOrganizationChancelleryViewModel From { get; set; }

        public override string FromStringValue {
            get {
                if (From == null) return string.Empty;
                else return this.From.Name;
            }
        }

        /// <summary>
        /// Кому
        /// </summary>
        public EmployeeViewModel To { get; set; }
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
