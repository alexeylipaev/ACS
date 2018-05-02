using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Кадровая история
    /// </summary>
    public partial class WorkHistory : SystemParameters
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя должности
        /// </summary>
        public string PostName { get; set; }

        public int DepartmentId { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public virtual Department Department { get; set; }

        public int PostsEmployeesСode1СId { get; set; }

        /// <summary>
        /// Пользователь и Код должности 1С
        /// </summary>
        public virtual PostEmployeeСode1С PostsEmployeesСode1С { get; set; }

        /// <summary>
        /// Ставка
        /// </summary>
        public double? Rate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
