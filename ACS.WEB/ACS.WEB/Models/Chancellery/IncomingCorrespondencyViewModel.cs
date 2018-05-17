﻿

namespace ACS.WEB.ViewModel
{
    public class IncomingCorrespondencyViewModel : BaseCorrespondencyViewModel
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public ExternalOrganizationChancelleryViewModel From { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        public EmployeeViewModel To { get; set; }
    }
}