using EventBus.Abstractions;
using Microsoft.AspNetCore.Builder;
using Sample.Domain.Users.EventHandlers;
using Sample.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.HttpApi.Unitily.Expand
{
    public static class ApplicationBuilderExpand
    {
        /// <summary>
        /// 初始化具体消息类型和消费实现
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder Subscribe(this IApplicationBuilder app)
        {
            IEventBus eventBus = app.ApplicationServices.GetService(typeof(IEventBus)) as IEventBus;

            #region 初始化具体消息类型和消费实现

            eventBus.Subscribe<SendShortMessageEvent, SendShortMessageEventHandler>();

            #endregion

            return app;
        }
    }
}
