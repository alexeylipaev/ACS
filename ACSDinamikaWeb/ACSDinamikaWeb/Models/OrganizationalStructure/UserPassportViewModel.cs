using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.ViewModel
{

    public class UserPassportViewModel : SystemParametersViewModel
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public string UnitCode { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public int? UserId { get; set; }

        //public virtual UserViewModel User { get; set; }
    }
}