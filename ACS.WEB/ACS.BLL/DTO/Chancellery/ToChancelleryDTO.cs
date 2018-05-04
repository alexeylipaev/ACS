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
        public ToChancelleryDTO()
        {
            ExternalOrganizations = new HashSet<ExternalOrganizationChancelleryDTO>();
            Employees = new HashSet<EmployeeDTO>();
        }

        public int Id { get; set; }

        public ICollection<ExternalOrganizationChancelleryDTO> ExternalOrganizations { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }

        public virtual int? Chancellery_Id { get; set; }
    }
}
