using System;

using System.ComponentModel.DataAnnotations;


namespace ACS.DAL.Entities
{

    public partial class Access: SystemParameters
    {
        public int Id { get; set; }

        public Guid? GuidObject { get; set; }

        public int? Value { get; set; }

        public string Note { get; set; }

        public int? TypeAccessId { get; set; }

        public virtual TypeAccess TypeAccess { get; set; }

        public int?  EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
