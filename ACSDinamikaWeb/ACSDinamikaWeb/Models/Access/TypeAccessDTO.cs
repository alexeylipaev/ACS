
using System.Collections.Generic;



namespace ACSWeb.Models
{

    public partial class TypeAccessViewModel : SystemParametersViewModel
    {
        public TypeAccessViewModel()
        {
            Accesses = new HashSet<AccessViewModel>();
        }
        public int Id { get; set; }

     
        public string Name { get; set; }

        public virtual ICollection<AccessViewModel> Accesses { get; set; }

    }
}
