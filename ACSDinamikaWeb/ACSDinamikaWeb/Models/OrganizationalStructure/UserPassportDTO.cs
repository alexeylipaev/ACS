using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.Models
{

    public class UserPassportViewModel : SystemParametersViewModel
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public string UnitCode { get; set; }

     
        public DateTime? DateOfIssue { get; set; }
    }
}