using System;

namespace ACS.WEB.ViewModel
{

    public partial class AccessViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        public Guid? GuidObject { get; set; }

        public int? Value { get; set; }

        public string Note { get; set; }

        public int? TypeAccessId { get; set; }

        //public virtual TypeAccessViewModel TypeAccess { get; set; }

        public int? EmployeeId { get; set; }

        //public virtual UserViewModel Employee { get; set; }
    }
}
