
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// внутреняя
    /// </summary>
    public class InternalCorrespondencyViewModel : BaseCorrespondencyViewModel
    {
        /// <summary>
        /// От кого"
        /// </summary>
        public EmployeeViewModel From { get; set; }

        public string FromStringValue
        {
            get
            {
                if (From == null) return string.Empty;
                else return this.From.FullName;
            }
        }

        /// <summary>
        /// Кому
        /// </summary>
        public List<EmployeeViewModel> To { get; set; }
        public string ToStringValue
        {
            get
            {
                StringBuilder result = new StringBuilder(string.Empty);

                if (To == null || To.Count == 0) return result.ToString();

                else
                    foreach (var t in To)
                        result.Append(t.FullName + "|");
                  
                return result.ToString();
            }
        }
    }
}
