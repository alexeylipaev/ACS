using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Код1С должности 
    /// </summary>
    public partial class PostsEmployeeСode1СViewModel : SystemParametersViewModel
    {

        public int id { get; set; }

        public Guid CodePost1C { get; set; }

        public virtual int? Employee_Id { get; set; }

    }
}
