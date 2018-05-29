using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.BusinessModels
{
 public static  class Constants
    {
        public const string FolderPath = @"X:\Подразделения\СВиССА\Файлы канцелярии\";
        public enum CorrespondencyType:byte { Incoming = 1, Outgoing, Internal }//1	Входящая; 2	Исходящая; 3	Внутреняя
    }
}
