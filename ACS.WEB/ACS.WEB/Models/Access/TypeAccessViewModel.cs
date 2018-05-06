
using System.Collections.Generic;



namespace ACS.WEB.ViewModel
{

    public partial class TypeAccessViewModel : SystemParametersViewModel
    {
        public TypeAccessViewModel()
        {
            Accesses = new HashSet<AccessViewModel>();
        }
        public int id { get; set; }

     
        public string Name { get; set; }

        public virtual ICollection<AccessViewModel> Accesses { get; set; }

    }
}
