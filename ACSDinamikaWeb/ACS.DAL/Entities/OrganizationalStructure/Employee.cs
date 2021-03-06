﻿using System;
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
    public partial class Employee : SystemParameters
    {

        public Employee()
        {
            Accesses = new HashSet<Access>();
            Chancelleries = new HashSet<Chancellery>();
            PostsEmployeesСode1С = new HashSet<PostsEmployeesСode1С>();
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

        public virtual ApplicationUser ApplicationUser { get; set; }

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
        public virtual ICollection<PostsEmployeesСode1С> PostsEmployeesСode1С { get; set; }
    }
}