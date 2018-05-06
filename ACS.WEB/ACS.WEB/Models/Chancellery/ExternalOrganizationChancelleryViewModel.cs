using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Внешняя организация
    /// </summary>
    public partial class ExternalOrganizationChancelleryViewModel : SystemParametersViewModel
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public string City { get; set; }


        public string Email { get; set; }

        public string Phone { get; set; }


    }
}
