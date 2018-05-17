using ACS.BLL.BusinessModels;
using ACS.WEB.ViewModel;
using System.Collections.Generic;

namespace ACS.WEB.Models.Chancellery
{
    public class ChancellerySearchModelVM
    {
        public ChancellerySearchModel ChancellerySearchModel { get; set; }

        public IEnumerable<object> Chancelleries { get; set; }
    }
}