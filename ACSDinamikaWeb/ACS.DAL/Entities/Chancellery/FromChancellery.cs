﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{

    /// <summary>
    /// От кого
    /// </summary>
    public partial class FromChancellery : SystemParameters
    {
        public int Id { get; set; }

        #region от пользователя

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        #endregion

        #region от внешней организации

        public int? ExternalOrganizationId { get; set; }

        public virtual ExternalOrganizationChancellery ExternalOrganization { get; set; }

        #endregion

        public int?  ChancelleryId { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }



}
