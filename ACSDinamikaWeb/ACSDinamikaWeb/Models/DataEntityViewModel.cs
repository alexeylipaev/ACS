using ACSWeb.ViewModel;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModels
{

    public partial class DataEntityViewModel : SystemParametersViewModel
    {

        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public int Object_id { get; set; }

    }
}
