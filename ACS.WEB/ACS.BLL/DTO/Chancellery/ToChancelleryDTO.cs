using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Кому
    /// </summary>
    public partial class ToChancelleryDTO : SystemParametersDTO
    {
        //public ToChancelleryDTO()
        //{
        //    ExternalOrganizations = new HashSet<ExternalOrganizationChancelleryDTO>();
        //    Employees = new HashSet<EmployeeDTO>();
        //}

        public int id { get; set; }

        public ExternalOrganizationChancelleryDTO ExternalOrganization { get; set; }
        public EmployeeDTO Employee { get; set; }

        public ChancelleryDTO Chancellery { get; set; }
    }
}
