using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    /// <summary>
    /// Код1С должности 
    /// </summary>
    public partial class PostUserСode1СViewModel : SystemParametersViewModel
    {

        public int Id { get; set; }


        public Guid CodePost1C { get; set; }

        public int? UserId { get; set; }

        public virtual UserViewModel User { get; set; }

    }
}
