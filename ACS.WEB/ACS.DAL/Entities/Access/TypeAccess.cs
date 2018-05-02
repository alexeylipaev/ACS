
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.DAL.Entities
{

    /// <summary>
    /// Тип доступа
    /// </summary>
    public partial class TypeAccess : SystemParameters
    {
        public TypeAccess()
        {
            Accesses = new HashSet<Access>();
        }
   
        public byte Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Access> Accesses { get; set; }

    }
}
