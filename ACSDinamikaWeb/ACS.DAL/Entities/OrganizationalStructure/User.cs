using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class User : SystemParameters
    {
      
        public User()
        {
            Accesses = new HashSet<Access>();
           
            //Chancelleries = new HashSet<Chancellery>();
            PostUserСode1С = new HashSet<PostUserСode1С>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string FName { get; set; }

        [StringLength(30)]
        public string LName { get; set; }

        [StringLength(25)]
        public string MName { get; set; }

        public int? PersonnelNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public virtual UserPassport Passport { get; set; }


        [StringLength(50)]
        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

        public virtual ASPIdentityUser ASPIdentityUser { get; set; }


        public virtual ICollection<Access> Accesses { get; set; }


       // public virtual ICollection<Chancellery> Chancelleries { get; set; }

        public virtual ICollection<PostUserСode1С> PostUserСode1С { get; set; }
    }
}