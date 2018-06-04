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
        public enum CorrespondencyType:byte { Incoming = 3, Outgoing, Internal }//3	Входящая; 4	Исходящая; 5 Внутреняя
    }
}
