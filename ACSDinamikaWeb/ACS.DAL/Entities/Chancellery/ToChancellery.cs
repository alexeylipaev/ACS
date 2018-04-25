using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Кому
    /// </summary>
    public partial class ToChancellery : SystemParameters
    {
        public ToChancellery()
        {
            ExternalOrganizations = new HashSet<ExternalOrganizationChancellery>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public ICollection<ExternalOrganizationChancellery> ExternalOrganizations { get; set; }
        public ICollection<User> Users { get; set; }

        public int? ChancelleryId { get; set; }
        public virtual Chancellery Chancellery { get; set; }
    }
}
