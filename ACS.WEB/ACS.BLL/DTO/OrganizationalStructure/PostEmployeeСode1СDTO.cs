using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Код1С должности 
    /// </summary>
    public partial class PostEmployeeСode1СDTO : SystemParametersDTO
    {

        public int Id { get; set; }

        public Guid CodePost1C { get; set; }

        //public int? EmployeeId { get; set; }

        public virtual EmployeeDTO Employee { get; set; }

    }
}
