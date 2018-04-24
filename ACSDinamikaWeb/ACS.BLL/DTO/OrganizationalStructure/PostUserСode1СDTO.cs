using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Коды должностей 1С
    /// </summary>
    public partial class PostUserСode1СDTO : SystemParametersDTO
    {

        public int Id { get; set; }


        public Guid CodePost1C { get; set; }


        public virtual UserDTO User { get; set; }

    }
}
