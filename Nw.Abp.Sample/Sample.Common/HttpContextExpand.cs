using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public static class HttpContextExpand
    {
        public static async Task<RequestInfo> GetRequestMessage(this HttpContext context)
        {
            var requestMethod = context.Request.Method;
            var requestURL = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";

            var accessToken = string.Empty;
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                accessToken = await context.GetTokenAsync("access_token");//添加身份验证的项目可以使用此方法获取到access_toekn
            }

            var requestBody = string.Empty;
            var queryString = string.Empty;
            string message = "";
            if (requestMethod == HttpMethods.Post)
            {
                Stream body = context.Request.Body;
                body.Position = 0;

                using (StreamReader stream = new StreamReader(body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = await stream.ReadToEndAsync();
                }
                body.Position = 0;
                message = requestBody;
            }
            if (requestMethod == HttpMethods.Get)
            {
                queryString = System.Web.HttpUtility.UrlDecode(context.Request.QueryString.ToString(), Encoding.UTF8);
                message = queryString;
            }
            return new RequestInfo(requestMethod, requestURL, message, accessToken);
        }
    }
}
