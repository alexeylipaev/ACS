using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    [ComplexType]
    public partial class PhoneInfo
    {
        public string PhoneInf { get; set; }
    }
}
