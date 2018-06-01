﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class EmployeeDTO : EntityDTO
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }
        public string Email { get; set; }
  
        public string FullName
        {
            get
            {
                string fullName = LName != null ? LName : string.Empty;
                fullName = FName != null ? string.IsNullOrWhiteSpace(fullName) ? FName : fullName + " " + FName : fullName;
                fullName = MName != null ? string.IsNullOrWhiteSpace(fullName) ? MName : fullName + " " + MName : fullName;
                return fullName;
            }
        }
        public Guid? Guid1C { get; set; }
        public int? ApplicationUserId { get; set; }
    }
}
