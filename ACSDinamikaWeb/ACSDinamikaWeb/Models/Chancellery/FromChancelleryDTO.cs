﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{


    public partial class FromChancelleryViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }


        public Guid? FromGuid { get; set; }


        public int? TableId { get; set; }

        public virtual ChancelleryViewModel Chancellery { get; set; }
    }
}