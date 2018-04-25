using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class UserViewModel : SystemParametersViewModel
    {

        public UserViewModel()
        {
            Accesses = new HashSet<AccessViewModel>();
    
            ////Chancelleries = new HashSet<Chancellery>();
            PostUserСode1С = new HashSet<PostUserСode1СViewModel>();
        }

        public int Id { get; set; }

      
        public string FName { get; set; }

       
        public string LName { get; set; }

       
        public string MName { get; set; }

        public string PersonnelNumber { get; set; }

      
        public DateTime? Birthday { get; set; }

        public UserPassportViewModel Passport { get; set; }


        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

       public virtual ASPIdentityUserViewModel ASPIdentityUser { get; set; }


       public virtual ICollection<AccessViewModel> Accesses { get; set; }


       //// public virtual ICollection<Chancellery> Chancelleries { get; set; }

       public virtual ICollection<PostUserСode1СViewModel> PostUserСode1С { get; set; }
    }
}