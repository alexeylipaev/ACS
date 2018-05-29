using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{

    public class JournalCorrespondencesInput : EntityViewModel
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        //[Display(Name = "Канцеляриские записи в журнале")]
        //public IEnumerable<int> Chancelleries { get; set; }
    }
}