using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{

    public static class MapSystemParamBLL<T, DTO>
    {
        public static void FillParamDTO(T entity, ref DTO entityDTO)
        {
            var sysparam = (entity as DAL.Entities.SystemParameters);
            var systemParametersDTO = (entityDTO as BLL.DTO.SystemParametersDTO);

            systemParametersDTO.s_AuthorId = sysparam.s_AuthorId;
            systemParametersDTO.s_EditDate = sysparam.s_EditDate;
            systemParametersDTO.s_EditorId = sysparam.s_EditorId;
            systemParametersDTO.s_InBasket = sysparam.s_InBasket;
            systemParametersDTO.s_IsLocked = sysparam.s_IsLocked;
            systemParametersDTO.s_LockedBy_Id = sysparam.s_LockedBy_Id;
            systemParametersDTO.s_Guid = sysparam.s_Guid;
            systemParametersDTO.s_DateCreation = sysparam.s_DateCreation;

        }

    }
}
