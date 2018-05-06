using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{

    public class EmployeePassportViewModel : SystemParametersViewModel
    {
        [Display(Name = "Серия")]
        public string Series { get; set; }
        [Display(Name = "Номер")]
        public string Number { get; set; }
        [Display(Name = "Кем выдан")]
        public string IssuedBy { get; set; }
        [Display(Name = "Код подразделения")]
        public string UnitCode { get; set; }
        [Display(Name = "Дата выдачи")]
        public DateTime? DateOfIssue { get; set; }

        public virtual int Employee_Id { get; set; }

    }
}