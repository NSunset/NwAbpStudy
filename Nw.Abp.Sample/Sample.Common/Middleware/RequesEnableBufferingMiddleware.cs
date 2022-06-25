using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Middleware
{
    /// <summary>
    /// 启用缓冲，吧请求信息加入缓冲区，避免只能读一次,最好加到最前面
    /// </summary>
    public class RequesEnableBufferingMiddleware
    {
        private readonly RequestDelegate next;

        public RequesEnableBufferingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            await next(context);
        }
    }
}
