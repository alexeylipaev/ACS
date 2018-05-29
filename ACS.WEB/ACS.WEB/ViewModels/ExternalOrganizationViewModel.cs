using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class ExternalOrganizationViewModel : EntityViewModel
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
