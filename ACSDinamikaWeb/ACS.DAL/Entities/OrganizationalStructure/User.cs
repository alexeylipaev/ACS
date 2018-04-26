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
            Chancelleries = new HashSet<Chancellery>();
            PostUserСode1С = new HashSet<PostUserСode1С>();
        }

        public int Id { get; set; }


        [Required]
        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public string PersonnelNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }


        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

        /// <summary>
        /// Доступы пользователя
        /// </summary>
        public virtual ICollection<Access> Accesses { get; set; }

        /// <summary>
        /// Канцелярские записи пользователя
        /// </summary>
        public virtual ICollection<Chancellery> Chancelleries { get; set; }

        /// <summary>
        /// Коды1С должностей пользователя
        /// </summary>
        public virtual ICollection<PostUserСode1С> PostUserСode1С { get; set; }
    }
}