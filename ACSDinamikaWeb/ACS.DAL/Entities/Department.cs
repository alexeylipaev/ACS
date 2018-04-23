using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{

    public partial class Department : SystemParameters
    {
       
        public Department()
        {
            ChildrenDepartments = new HashSet<Department>();
        }

        public int Id { get; set; }

        [Required]
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

      
        public virtual ICollection<Department> ChildrenDepartments { get; set; }

        public virtual Department ParentDepartment { get; set; }

    }
}
