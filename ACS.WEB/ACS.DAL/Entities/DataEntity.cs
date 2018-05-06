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
    public partial class DataEntity : SystemParameters
    {

        public int id { get; set; }

        /// <summary>
        /// Имя типа/таблицы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// id таблицы 
        /// </summary>
        public int Object_id { get; set; }

    }
}
