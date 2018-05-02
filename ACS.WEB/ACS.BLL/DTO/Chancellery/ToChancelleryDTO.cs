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
        //    Employees = new HashSet<UserDTO>();
        //}

        public int Id { get; set; }

        //public ICollection<ExternalOrganizationChancelleryDTO> ExternalOrganizations { get; set; }
        //public ICollection<UserDTO> Employees { get; set; }

        public int? ChancelleryId { get; set; }
        //public virtual ChancelleryDTO Chancellery { get; set; }
    }
}
