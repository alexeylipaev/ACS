using ACS.WEB.ViewModel;
using System.Collections.Generic;

namespace ACS.WEB.Models
{
    public class EmployeeMultiSelector
    {
        public EmployeeMultiSelector()
        {
            SelectedId = new HashSet<int>();
        }
        public int Id { get; set; }

        public ICollection<EmployeeViewModel> RoleCollection { get; set; }

        public ICollection<int> SelectedId { get; set; }
    }
}