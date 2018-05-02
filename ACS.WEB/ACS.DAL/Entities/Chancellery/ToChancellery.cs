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
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public ICollection<ExternalOrganizationChancellery> ExternalOrganizations { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public int? ChancelleryId { get; set; }
        public virtual Chancellery Chancellery { get; set; }
    }
}
