using ACS.BLL.BusinessModels;
using ACS.WEB.ViewModel;
using System.Collections.Generic;

namespace ACS.WEB.Models.Chancellery
{
    public class ChancellerySearchModelVM : ChancellerySearchModel/*<T> where T:class*/
    {
        //public ChancellerySearchModel ChancellerySearchModel { get; set; }

        public IEnumerable<object> Chancelleries { get; set; }

        public SelectedFolderChancellery SelectedFolder { get; set; }
    }
}