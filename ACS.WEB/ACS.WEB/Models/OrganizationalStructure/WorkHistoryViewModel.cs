﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{

    public partial class WorkHistoryViewModel : SystemParametersViewModel
    {
        public int id { get; set; }

        /// <summary>
        /// Имя должности
        /// </summary>
        public string PostName { get; set; }

        public int DepartmentId { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        //public virtual DepartmentViewModel Department { get; set; }

        public int PostsEmployeesСode1Сid { get; set; }

        /// <summary>
        /// Пользователь и Код должности 1С
        /// </summary>
        //public virtual PostsEmployeesСode1СViewModel PostsEmployeesСode1С { get; set; }

        /// <summary>
        /// Ставка
        /// </summary>
        public double? Rate { get; set; }

      
        public DateTime? StartDate { get; set; }

       
        public DateTime? EndDate { get; set; }

    }
}
