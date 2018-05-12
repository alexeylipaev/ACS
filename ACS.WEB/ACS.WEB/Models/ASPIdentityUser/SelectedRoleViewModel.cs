using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    public class SelectedRoleViewModel
    {
        public SelectedRoleViewModel()
        {
            SelectedId = new HashSet<int>();
        }
        public int Id { get; set; }
      
        public ICollection<ApplicationRoleViewModel> RoleCollection { get; set; }

        public ICollection<int> SelectedId { get; set; }
    }
}