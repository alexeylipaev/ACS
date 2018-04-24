using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{

    public partial class DepartmentDTO : SystemParametersDTO
    {

        public DepartmentDTO()
        {
            ChildrenDepartments = new HashSet<DepartmentDTO>();
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


        public virtual ICollection<DepartmentDTO> ChildrenDepartments { get; set; }

        public virtual DepartmentDTO ParentDepartment { get; set; }

    }
}
