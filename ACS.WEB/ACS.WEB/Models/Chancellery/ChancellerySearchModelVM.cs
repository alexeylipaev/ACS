using ACS.BLL.BusinessModels;
using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Models.Chancellery
{
    public class ChancellerySearchModelVM
    {
        public ChancellerySearchModel ChancellerySearchModel { get; set; }

        public IEnumerable<ChancelleryViewModel> Chancelleries { get; set; }
    }
}