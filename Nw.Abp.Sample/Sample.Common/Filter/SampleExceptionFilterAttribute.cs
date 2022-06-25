using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Common
{
    public class SampleExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<SampleExceptionFilterAttribute> logger;

        public SampleExceptionFilterAttribute(ILogger<SampleExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public async void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                ApiResult apiResult;
                if (context.Exception is UserException)
                {
                    apiResult = ApiResult.ForbiddenError(context.Exception.Message);
                }
                else if (context.Exception is ClientPassParamException)
                {
                    apiResult = ApiResult.PreconditionFailedError(context.Exception.Message);
                }
                else
                {
                    apiResult = ApiResult.ServerError("服务端内部错误，请稍后重试");
                }

                RequestInfo requestInfo = await context.HttpContext.GetRequestMessage();
                string errorMsg = $"Method：{requestInfo.RequestMethod}\r\nPath：{requestInfo.RequestURL}\r\nQuestMsg：{requestInfo.RequestMessage}\r\ntoken：{requestInfo.AccessToken}";

                if (apiResult.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    logger.LogError(context.Exception, errorMsg);
                }
                else
                {
                    logger.LogDebug(context.Exception, errorMsg);
                }

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                //吧返回信息写入response
                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
            }
            context.ExceptionHandled = true;
        }


    }
}
