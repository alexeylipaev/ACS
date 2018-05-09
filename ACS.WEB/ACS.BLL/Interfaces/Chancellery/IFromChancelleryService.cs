using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IFromChancelleryService : IDisposable
    {
        /// <summary>
        /// Получить внешнюю организацию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExternalOrganizationChancelleryDTO GetExternalOrganizationChancelleryDTO(int? id);

        /// <summary>
        /// Все внешнии организации
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExternalOrganizationChancelleryDTO> GetAllExternalOrganizationsChancelleryDTO();

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeDTO UserDTO(int? id);

        /// <summary>
        /// Все пользователя
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeDTO> GetAllUsers();


        FromChancelleryDTO GetFromChancellery(int? id);

        IEnumerable<FromChancelleryDTO> GetFromChancellery();

        void CreateFromChancellery(FromChancelleryDTO FromChancelleryDTO, string authorEmail);

        void UpdateFromChancellery(FromChancelleryDTO FromChancelleryDTO, string authorEmail);


    }
}
