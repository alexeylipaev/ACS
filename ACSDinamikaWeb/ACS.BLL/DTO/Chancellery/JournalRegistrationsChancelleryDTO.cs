using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Журнал канцелярский
    /// </summary>
    public partial class JournalRegistrationsChancelleryDTO : SystemParametersDTO
    {

        //public JournalRegistrationsChancelleryDTO()
        //{
        //    Chancelleries = new HashSet<ChancelleryDTO>();
        //}

        public int Id { get; set; }

       
        public string Name { get; set; }


        //public virtual ICollection<ChancelleryDTO> Chancelleries { get; set; }

    }
}
