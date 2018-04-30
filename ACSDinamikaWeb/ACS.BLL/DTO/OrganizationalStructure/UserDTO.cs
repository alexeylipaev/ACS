﻿using System;
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

        //public UserDTO()
        //{
        //    Accesses = new HashSet<AccessDTO>();
        //    Chancelleries = new HashSet<ChancelleryDTO>();
        //    PostUserСode1С = new HashSet<PostUserСode1СDTO>();
        //}

        public int Id { get; set; }

       
        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public string PersonnelNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

        ///// <summary>
        ///// Доступы пользователя
        ///// </summary>
        //public virtual ICollection<AccessDTO> Accesses { get; set; }

        ///// <summary>
        ///// Канцелярские записи пользователя
        ///// </summary>
        //public virtual ICollection<ChancelleryDTO> Chancelleries { get; set; }

        ///// <summary>
        ///// Коды1С должностей пользователя
        ///// </summary>
        //public virtual ICollection<PostUserСode1СDTO> PostUserСode1С { get; set; }
    }
}