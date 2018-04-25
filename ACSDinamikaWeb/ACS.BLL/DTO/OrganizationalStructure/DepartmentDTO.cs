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
            ChildrenDepartmentDTOs = new HashSet<DepartmentDTO>();
            WorkHistories = new HashSet<WorkHistoryDTO>();
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

        #region связь с родителем 

        public int? ParentDepartmentDTOId { get; set; }

        public virtual DepartmentDTO ParentDepartmentDTO { get; set; }

        #endregion

        public virtual ICollection<DepartmentDTO> ChildrenDepartmentDTOs { get; set; }

        /// <summary>
        /// Подключения к подразделению
        /// </summary>
        public virtual ICollection<WorkHistoryDTO> WorkHistories { get; set; }

    }
}
