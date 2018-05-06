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
            WorkHistories = new HashSet<WorkHistoryDTO>();
        }

        public int id { get; set; }


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

        #region связь с родителем 

        //public int? ParentDepartmentId { get; set; }

        public virtual int? ParentDepartment_Id { get; set; }

        #endregion

        public virtual ICollection<DepartmentDTO> ChildrenDepartments { get; set; }

        /// <summary>
        /// Подключения к подразделению
        /// </summary>
        public virtual ICollection<WorkHistoryDTO> WorkHistories { get; set; }

    }
}
