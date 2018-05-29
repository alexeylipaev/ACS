using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class EntityViewModel : SystemParametersViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
    }
}