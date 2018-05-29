using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.BusinessModels
{
    public static class Helper
    {
        public static string RemoveSpacesBeginnEndStr(string str)
        {
            string result;
            if (str != null)
                result = str.TrimStart().TrimEnd();
            else result = string.Empty;
            return result;
        }
    }
}
