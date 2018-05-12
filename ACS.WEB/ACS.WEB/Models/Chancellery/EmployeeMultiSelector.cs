using ACS.WEB.ViewModel;
using System.Collections.Generic;

namespace ACS.WEB.Models
{
    public class EmployeeMultiSelector
    {
        public EmployeeMultiSelector()
        {
            SelectedId = new HashSet<int>();
            EmplCollection = new HashSet<EmployeeViewModel>();
        }
        public int Id { get; set; }

        public ICollection<EmployeeViewModel> EmplCollection { get; set; }

        public ICollection<int> SelectedId { get; set; }
    }
}