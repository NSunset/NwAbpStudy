using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    /// <summary>
    /// 客户端传参错误
    /// </summary>
    public class ClientPassParamException : Exception
    {
        public ClientPassParamException(string message, Exception exception = null)
            : base(message, exception)
        {

        }
    }
}
