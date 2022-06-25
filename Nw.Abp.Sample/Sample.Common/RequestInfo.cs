using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public class RequestInfo
    {
        public string RequestMethod { get; }

        public string RequestURL { get; }

        public string AccessToken { get; }

        public string RequestMessage { get; }

        public RequestInfo(string method, string url, string message, string token = null)
        {
            this.RequestMethod = method;
            RequestURL = url;
            RequestMessage = message;
            AccessToken = token;
        }
    }
}
