using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{

    public class EmployeePassportDTO : SystemParametersDTO
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public string UnitCode { get; set; }

        public DateTime? DateOfIssue { get; set; }


        public virtual EmployeeDTO Employee { get; set; }
    }
}