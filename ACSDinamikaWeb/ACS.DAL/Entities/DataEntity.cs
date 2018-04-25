using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Таблица сущностей/sql таблиц (пока не понятно)
    /// </summary>
    [Table("DataTable")]
    public partial class DataEntity : SystemParameters
    {

        public int Id { get; set; }

        /// <summary>
        /// Имя типа/таблицы
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Id таблицы 
        /// </summary>
        [Column("object_id")]
        public int Object_id { get; set; }

    }
}
