using ACS.BLL.DTO;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB
{

    public static class MapSystemParamVM_to_DTO<VM, DTO> where DTO : SystemParametersDTO where VM : SystemParametersViewModel
    {
        public static void FillParamDTO(VM entityVM, ref DTO entityDTO)
        {
            entityDTO.s_AuthorId = entityVM.s_AuthorId;
            entityDTO.s_EditDate = entityVM.s_EditDate;
            entityDTO.s_EditorId = entityVM.s_EditorId;
            entityDTO.s_InBasket = entityVM.s_InBasket;
            entityDTO.s_IsLocked = entityVM.s_IsLocked;
            entityDTO.s_LockedBy_Id = entityVM.s_LockedBy_Id;
        }
    }
    public static class MapSystemParamDTO_to_VM<DTO, VM> where DTO : SystemParametersDTO where VM : SystemParametersViewModel
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
