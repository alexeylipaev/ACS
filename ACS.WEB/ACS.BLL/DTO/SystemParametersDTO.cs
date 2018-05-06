using System;
using System.ComponentModel;


namespace ACS.BLL.DTO
{
    public class SystemParametersDTO
    {
        public Guid s_Guid { get; private set; } = Guid.NewGuid();

        public int s_AuthorId { get; set; } = 1;

        public DateTime s_DateCreation { get; private set; } = DateTime.Now;

        public int s_EditorId { get; set; } = 1;

        public DateTime s_EditDate { get; set; } = DateTime.Now;

        public bool? s_IsLocked { get; set; } = false;

        public int? s_LockedBy_Id { get; set; }

        public bool s_InBasket { get; set; } = false;
    }
}