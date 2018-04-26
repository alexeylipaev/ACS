using System;

namespace ACSWeb.ViewModel
{

    public partial class AccessViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        public Guid? GuidObject { get; set; }

        public int? Value { get; set; }

        public string Note { get; set; }

        public int? TypeAccessId { get; set; }

        //public virtual TypeAccessViewModel TypeAccess { get; set; }

        public int? UserId { get; set; }

        //public virtual UserViewModel User { get; set; }
    }
}
