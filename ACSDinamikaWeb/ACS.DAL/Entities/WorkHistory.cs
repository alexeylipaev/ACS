using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{

    public partial class WorkHistory : SystemParameters
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя должности
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Пользователь и Код должности 1С
        /// </summary>
        public virtual PostUserСode1С PostUserСode1С { get; set; }

        public double? Rate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

    }
}
