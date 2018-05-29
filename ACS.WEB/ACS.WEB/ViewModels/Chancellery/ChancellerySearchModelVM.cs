using ACS.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class ChancellerySearchModelVM : ChancellerySearchModel/*<T> where T:class*/
    {
        public ChancellerySearchModelVM() : base()
        {
            DateTime today = DateTime.Today;
            this.RegistryDateFrom = today;
            this.RegistryDateTo = today.AddDays(1);
        }
        //public ChancellerySearchModel ChancellerySearchModel { get; set; }

        public IEnumerable<object> Chancelleries { get; set; }

    }
}