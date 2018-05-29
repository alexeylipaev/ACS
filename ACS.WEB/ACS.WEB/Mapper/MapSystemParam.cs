using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB
{

    public static class MapSystemParam<DTO, VM> where DTO : SystemParametersDTO where VM : SystemParametersViewModel
    {
        public static void FillParamDTO(DTO entityDTO, ref VM entityVM)
        {
            entityVM.s_AuthorId = entityDTO.s_AuthorId;
            entityVM.s_EditDate = entityDTO.s_EditDate;
            entityVM.s_EditorId = entityDTO.s_EditorId;
            entityVM.s_InBasket = entityDTO.s_InBasket;
            entityVM.s_IsLocked = entityDTO.s_IsLocked;
            entityVM.s_LockedBy_Id = entityDTO.s_LockedBy_Id;
        }
    }
}
