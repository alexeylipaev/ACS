using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IFromChancelleryService
    {
        /// <summary>
        /// Получить внешнюю организацию
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ExternalOrganizationChancelleryDTO GetExternalOrganizationChancelleryDTO(int? Id);

        /// <summary>
        /// Все внешнии организации
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExternalOrganizationChancelleryDTO> GetAllExternalOrganizationsChancelleryDTO();

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserDTO UserDTO(int? Id);

        /// <summary>
        /// Все пользователя
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDTO> GetAllUsers();


        FromChancelleryDTO GetFromChancellery(int? Id);

        IEnumerable<FromChancelleryDTO> GetFromChancellery();

        void MakeFromChancellery(FromChancelleryDTO FromChancelleryDTO, string authorEmail);

        void UpdateFromChancellery(FromChancelleryDTO FromChancelleryDTO, string authorEmail);

        void Dispose();
    }
}
