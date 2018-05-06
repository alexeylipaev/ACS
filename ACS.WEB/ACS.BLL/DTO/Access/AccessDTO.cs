using System;

namespace ACS.BLL.DTO
{

    public partial class AccessDTO : SystemParametersDTO
    {
        public int id { get; set; }

        public Guid? GuidObject { get; set; }

        public int? Value { get; set; }

        public string Note { get; set; }

        //public int? TypeAccessId { get; set; }

        public virtual TypeAccessDTO TypeAccess { get; set; }

        public virtual int? Employee_Id { get; set; }
    }
}
