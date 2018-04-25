using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderChancelleryDTO : SystemParametersDTO
    {

        public FolderChancelleryDTO()
        {
            Chancelleries = new HashSet<ChancelleryDTO>();
        }

        public int Id { get; set; }

       
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public virtual ICollection<ChancelleryDTO> Chancelleries { get; set; }
    }
}
