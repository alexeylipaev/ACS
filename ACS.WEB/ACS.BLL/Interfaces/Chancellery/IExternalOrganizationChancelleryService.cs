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
        //int CreateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        int CreateOrUpdateExternalOrganization(ExternalOrganizationChancelleryDTO ExternalOrganizationChancelleryDTO, string authorEmail);

        //int UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        ExternalOrganizationChancelleryDTO GetExternalOrganization(int id);

        IEnumerable<ExternalOrganizationChancelleryDTO> GetExternalOrganizationsChancellery();

        int DeleteExternalOrganization(int id);

    }
}
