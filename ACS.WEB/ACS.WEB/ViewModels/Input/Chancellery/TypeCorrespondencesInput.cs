using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class TypeCorrespondencesInput : EntityViewModel
    {
        [Display(Name = "Тип")]
        public string Name { get; set; }

        //[Display(Name = "Канцеляриские записи данного типа")]
        //public IEnumerable<int> Chancelleries { get; set; }
    }
}