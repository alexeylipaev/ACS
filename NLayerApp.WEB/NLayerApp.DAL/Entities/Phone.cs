using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace NLayerApp.DAL.Entities
{
    public partial class Phone : SystemParameters
    {
        public Phone()
        {
            //PhoneInfo = new PhoneInfo();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }

        public virtual PhoneInfo PhoneInfo { get; set; } 
    }
}