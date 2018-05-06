using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ApplicationRoleViewModel 
    {

        public int id { get; set; }
      
        [Display(Name = "Наименование")]
        public string Name { get; set; }

    }
}
