using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{

    public partial class WorkHistoryDTO : SystemParametersDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя должности
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public virtual DepartmentDTO Department { get; set; }
    
        /// <summary>
        /// Пользователь и Код должности 1С
        /// </summary>
        public virtual PostUserСode1СDTO PostUserСode1С { get; set; }

        public double? Rate { get; set; }

      
        public DateTime? StartDate { get; set; }

       
        public DateTime? EndDate { get; set; }

    }
}
