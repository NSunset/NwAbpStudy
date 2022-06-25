using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Middleware
{
    public static class ApplicationBuilderExpand
    {
        public static IApplicationBuilder UseRequesEnableBufferingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequesEnableBufferingMiddleware>();
        }
    }
}
