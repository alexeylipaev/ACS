using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{

    public partial class WorkHistoryViewModel : SystemParametersViewModel
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
        //public virtual DepartmentViewModel Department { get; set; }

        public int PostUserСode1СId { get; set; }

        /// <summary>
        /// Пользователь и Код должности 1С
        /// </summary>
        //public virtual PostUserСode1СViewModel PostUserСode1С { get; set; }

        /// <summary>
        /// Ставка
        /// </summary>
        public double? Rate { get; set; }

      
        public DateTime? StartDate { get; set; }

       
        public DateTime? EndDate { get; set; }

    }
}
