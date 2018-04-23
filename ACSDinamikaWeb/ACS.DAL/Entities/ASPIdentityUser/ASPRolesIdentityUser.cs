using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class ASPRolesIdentityUser : SystemParameters
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ASPIdentityUser IdentityUser { get; set; }

    }
}
