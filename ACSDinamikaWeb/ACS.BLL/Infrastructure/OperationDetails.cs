using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Infrastructure
{
    /// <summary>
    /// Данный класс будет хранить информацию об успешности операции. Свойство Succeeded указывает, успешна ли операция, а свойства Message и Property будут хранить соответственно сообщение об ошибке и свойство, на котормо произошла ошибка.
    /// </summary>
    public class OperationDetails
    {
        public OperationDetails(bool succeeded, string message, string prop)
        {
            this.Succeeded = succeeded;
            Message = message;
            Property = prop;
        }
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
