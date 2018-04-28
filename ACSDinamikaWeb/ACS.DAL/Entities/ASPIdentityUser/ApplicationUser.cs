using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACS.DAL.Entities
{

    public partial class ApplicationUser : IdentityUser
    {
        //public string Email { get; set; }

        public virtual User User { get; set; }

        //public string UserName { get; set; }
    }
}