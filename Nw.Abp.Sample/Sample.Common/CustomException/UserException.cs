using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    /// <summary>
    /// 传给前端友好错误信息
    /// </summary>
    public class UserException : Exception
    {
        public UserException(string message, Exception exception = null) : base(message, exception)
        {

        }
    }
}
