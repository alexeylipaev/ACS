using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModels
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ApplicationRoleViewModel 
    {
        [Display(Name = "ID")]
        public int id { get; set; }
      
        [Display(Name = "Наименование")]
        public string Name { get; set; }

    }
    public class SelectedRoleViewModel
    {
        //public SelectedRoleViewModel()
        //{
        //    SelectedId = new HashSet<int>();
        //    RoleCollection = new HashSet<ApplicationRoleViewModel>();
        //}
        public int Id { get; set; }


        /// <summary>
        /// Хранит в коллекцию, чтобы осуществлять по ней выбор
        /// </summary>
        public IEnumerable<ApplicationRoleViewModel> RoleCollection { get; set; }

        public IEnumerable<int> SelectedId { get; set; }
    }
}
