using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    public class SelectedExternalOrgViewModel
    {
        public SelectedExternalOrgViewModel()
        {
            SelectedId = new HashSet<int>();
        }
        public int Id { get; set; }

        public ICollection<ExternalOrganizationChancelleryViewModel> ExternalOrganizationCollection { get; set; }

        public ICollection<int> SelectedId { get; set; }
    }
}