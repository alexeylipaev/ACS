using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACS.DAL.Entities
{
    //[ComplexType]
    public class UserPassport : SystemParameters
    {
        [Key]
        public int Id { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public string UnitCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfIssue { get; set; }

        /***************** 1 to 1 Passport to User *********************/

        public int? UserId { get; set; }

        public virtual User User { get; set; }

    }
}