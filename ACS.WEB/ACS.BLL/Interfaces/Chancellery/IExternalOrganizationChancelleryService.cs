using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IExternalOrganizationChancelleryService : IDisposable
    {
        void MakeExternalOrganizationChancellery(ExternalOrganizationChancelleryDTO ExternalOrganizationChancelleryDTO, string authorEmail);

        void UpdateExternalOrganizationChancellery(ExternalOrganizationChancelleryDTO ExternalOrganizationChancelleryDTO, string authorEmail);

        ExternalOrganizationChancelleryDTO GetExternalOrganizationChancellery(int? id);
        IEnumerable<ExternalOrganizationChancelleryDTO> GetExternalOrganizationChancellery();

    }
}
