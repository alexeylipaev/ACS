using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class UserDTO : SystemParametersDTO
    {

        public UserDTO()
        {
            Accesses = new HashSet<AccessDTO>();

            ////Chancelleries = new HashSet<Chancellery>();
            PostUserСode1С = new HashSet<PostUserСode1СDTO>();
        }

        public int Id { get; set; }

      
        public string FName { get; set; }

       
        public string LName { get; set; }

       
        public string MName { get; set; }

        public int? PersonnelNumber { get; set; }

      
        public DateTime? Birthday { get; set; }

        public virtual UserPassportDTO Passport { get; set; } = null;


        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

       public virtual ASPIdentityUserDTO ASPIdentityUser { get; set; }


       public virtual ICollection<AccessDTO> Accesses { get; set; }


       //// public virtual ICollection<Chancellery> Chancelleries { get; set; }

       public virtual ICollection<PostUserСode1СDTO> PostUserСode1С { get; set; }
    }
}