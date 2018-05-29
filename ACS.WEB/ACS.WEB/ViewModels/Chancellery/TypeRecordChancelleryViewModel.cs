using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class TypeRecordChancelleryViewModel : EntityViewModel
    {
        [Display(Name = "Тип")]
        public string Name { get; set; }

        [Display(Name = "ID канцелярских  записей данного типа")]
        public string Chancelleries { get; set; }
        public override string ToString()
        {
            return this.Name ?? "";
        }
    }
}