using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{

    public partial class DataEntityDTO : SystemParametersDTO
    {

        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public int object_id { get; set; }

        
        public string type_desc { get; set; }


    }
}
