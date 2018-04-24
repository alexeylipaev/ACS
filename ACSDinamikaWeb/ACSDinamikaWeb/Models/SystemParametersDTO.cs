using System;
using System.ComponentModel;


namespace ACSWeb.Models
{
    public class SystemParametersViewModel
    {
      
        public Guid s_Guid { get; private set; }

        public int? s_AuthorID { get;  set; }

     
        public DateTime s_DateCreation { get; private set; }

        public int? s_EditorID { get;  set; }

       
        
        public DateTime s_EditDate { get; private set; }

        public bool? s_IsLocked { get; set; }

        public int? s_LockedBy_Id { get; set; }

        public bool? s_InBasket { get; set; }
    }
}