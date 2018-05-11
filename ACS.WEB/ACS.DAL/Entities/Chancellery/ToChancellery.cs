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
            //ExternalOrganizations = new HashSet<ExternalOrganizationChancellery>();
            //Employees = new HashSet<Employee>();
        }

        public int id { get; set; }

        public virtual ExternalOrganizationChancellery ExternalOrganization { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }
}
