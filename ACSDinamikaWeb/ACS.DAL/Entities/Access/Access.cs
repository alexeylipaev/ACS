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

        public virtual TypeAccess TypeAccess { get; set; }

        public virtual User User { get; set; }
    }
}
