using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IExternalOrganizationChancelleryService
    {
        void MakeExternalOrganizationChancellery(ExternalOrganizationChancelleryDTO ExternalOrganizationChancelleryDTO);
        ExternalOrganizationChancelleryDTO GetExternalOrganizationChancellery(int? id);
        IEnumerable<ExternalOrganizationChancelleryDTO> GetExternalOrganizationChancellery();
        void Dispose();
    }
}
