
using System.Collections.Generic;



namespace ACS.BLL.DTO
{

    public partial class TypeAccessDTO : SystemParametersDTO
    {
        public TypeAccessDTO()
        {
            Accesses = new HashSet<AccessDTO>();
        }
        public int id { get; set; }

     
        public string Name { get; set; }

        public virtual ICollection<AccessDTO> Accesses { get; set; }

    }
}
