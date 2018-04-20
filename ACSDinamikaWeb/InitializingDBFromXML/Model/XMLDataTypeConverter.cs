using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializingDBFromXML.Model
{
    static public class XMLDataTypeConverter
    {
        public static bool ToBoolean(string value)
        {
            return (value == "Да");
        }

        public static DateTime GetDateTime(string value)
        {
            if (String.IsNullOrEmpty(value))
                return DateTime.MinValue;

            DateTime dateTime = Convert.ToDateTime(value);
            int year = dateTime.Year;

            if ((year < 1753) | (year > 9999))
            {
                return DateTime.MinValue;
            }

            return dateTime;
        }

        public static string DiscardZeros(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return null;

            char[] symbols = value.ToCharArray();
            string newValue = string.Empty;
            bool isBegin = true;

            foreach (char symbol in symbols)
            {
                if (isBegin && (symbol == '0'))
                    continue;
                else
                    isBegin = false;

                newValue += symbol;
            }

            if ((newValue.Length == 0) && (value.Length > 0) && (value.Last() == '0'))
                return "0";

            return newValue;
        }
    }
}
