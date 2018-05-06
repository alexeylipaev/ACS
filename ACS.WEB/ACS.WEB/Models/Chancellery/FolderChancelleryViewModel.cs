﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderChancelleryViewModel : SystemParametersViewModel
    {

        //public FolderChancelleryViewModel()
        //{
        //    Chancelleries = new HashSet<ChancelleryViewModel>();
        //}

        public int id { get; set; }

       
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        //public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }
    }
}
