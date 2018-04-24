using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{

    public partial class DepartmentViewModel : SystemParametersViewModel
    {

        public DepartmentViewModel()
        {
            ChildrenDepartments = new HashSet<DepartmentViewModel>();
        }

        public int Id { get; set; }

      
        public string Name { get; set; }

        /// <summary>
        /// Код подразделения 1С
        /// </summary>
        public int? Code1C { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Неактивное
        /// </summary>
        public bool? Inactive { get; set; }


        public virtual ICollection<DepartmentViewModel> ChildrenDepartments { get; set; }

        public virtual DepartmentViewModel ParentDepartment { get; set; }

    }
}
