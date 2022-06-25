using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public class ApiResult
    {
        /// <summary>
        /// 请求出否成功处理
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// 请求状态码
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 服务器处理正常，返回客户端消息
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public static ApiResult Ok(object data = null)
        {
            return new ApiResult
            {
                IsOk = true,
                StatusCode = StatusCodes.Status200OK,
                Data = data,
                ErrorMessage = null
            };
        }

        /// <summary>
        /// 服务端错误
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static ApiResult Error(int statusCode, string errorMessage)
        {
            return new ApiResult
            {
                IsOk = false,
                StatusCode = statusCode,
                Data = null,
                ErrorMessage = errorMessage
            };
        }

        /// <summary>
        /// 服务端错误
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult ServerError(string errorMessage)
        {
            return Error(StatusCodes.Status500InternalServerError, errorMessage);
        }

        /// <summary>
        /// 客户端请求接口传递参数不对
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult PreconditionFailedError(string errorMessage)
        {
            return Error(StatusCodes.Status412PreconditionFailed, errorMessage);
        }

        /// <summary>
        /// 验证数据不通过无法完成操作
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult ForbiddenError(string errorMessage)
        {
            return Error(StatusCodes.Status403Forbidden, errorMessage);
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <returns></returns>
        public static ApiResult UnauthorizedError()
        {
            return Error(StatusCodes.Status401Unauthorized, null);
        }
    }
}
