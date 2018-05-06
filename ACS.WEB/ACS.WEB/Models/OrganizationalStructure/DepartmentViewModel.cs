using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{

    public partial class DepartmentViewModel : SystemParametersViewModel
    {

        //public DepartmentViewModel()
        //{
        //    ChildrenDepartments = new HashSet<DepartmentViewModel>();
        //    WorkHistories = new HashSet<WorkHistoryViewModel>();
        //}

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

        public int? ParentDepartmentId { get; set; }

        //public virtual DepartmentViewModel ParentDepartment { get; set; }

        #endregion

        //public virtual ICollection<DepartmentViewModel> ChildrenDepartments { get; set; }

        ///// <summary>
        ///// Подключения к подразделению
        ///// </summary>
        //public virtual ICollection<WorkHistoryViewModel> WorkHistories { get; set; }

    }
}
