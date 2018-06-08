using ACS.BLL.BusinessModels;
using System;
using System.Collections.Generic;

namespace ACS.WEB.ViewModels
{
    public class ChancellerySearchModelVM : ChancellerySearchModel
    {
        public ChancellerySearchModelVM() : base()
        {
            DateTime today = DateTime.Today;
            this.RegistryDateFrom = today;
            this.RegistryDateTo = today.AddDays(1);
        }

        public IEnumerable<object> Chancelleries { get; set; }

    }
}