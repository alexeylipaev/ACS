using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{

    public partial class DataEntityDTO : SystemParametersDTO
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
