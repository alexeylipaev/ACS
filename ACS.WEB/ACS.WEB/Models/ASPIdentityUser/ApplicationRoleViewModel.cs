using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ApplicationRoleViewModel : SystemParametersViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
