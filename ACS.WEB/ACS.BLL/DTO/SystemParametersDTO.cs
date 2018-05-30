using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public class SystemParametersDTO
    {
        public Guid s_Guid { get;  set; } 

        public int s_AuthorId { get; set; } 

        public DateTime s_DateCreation { get;  set; } 

        public int s_EditorId { get; set; }

        public DateTime s_EditDate { get; set; } 

        public bool? s_IsLocked { get; set; } 

        public int? s_LockedBy_Id { get; set; }

        public bool s_InBasket { get; set; }
    }
}
