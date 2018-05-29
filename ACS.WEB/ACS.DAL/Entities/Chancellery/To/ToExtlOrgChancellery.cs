using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
   public class ToExtlOrgChancellery :Entity
    {
        public int? ExternalOrganizationId { get; set; }
        public virtual ExternalOrganization ExternalOrganization { get; set; }

        public int ChancelleryId { get; set; }
        public virtual Chancellery Chancellery { get; set; }
    }
}
