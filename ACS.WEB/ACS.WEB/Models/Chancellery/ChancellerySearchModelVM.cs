using ACS.BLL.BusinessModels;
using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;

namespace ACS.WEB.Models.Chancellery
{
    public class ChancellerySearchModelVM : ChancellerySearchModel/*<T> where T:class*/
    {
        public ChancellerySearchModelVM()
        {
            DateTime today = DateTime.Today;
            this.RegistryDateFrom = today;
            this.RegistryDateTo = today.AddDays(1);
        }

        public IEnumerable<object> Chancelleries { get; set; }

        public SelectedFolderChancellery SelectedFolder { get; set; }
    }
}