﻿using ACS.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class IncomingCorrespondencyInput : CorrespondencesBaseInput
    {
        public IncomingCorrespondencyInput() : base()
        {
            this.TypeRecordChancelleryId = (int)Constants.CorrespondencyType.Incoming;
        }

        /// <summary>
        /// От кого"
        /// </summary>
        [Display(Name = "От кого")]
        public int? From_ExternalOrganizationChancelleryId { get; set; }

        /// <summary>
        /// Кому
        /// </summary>
        [Display(Name = "Кому")]
        public int? To_EmployeeId { get; set; }
    }
}