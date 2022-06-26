using EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using Sample.Domain.Models;
using Sample.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sample.Domain.Users.EventHandlers
{
    public class SendShortMessageEventHandler : IIntegrationEventHandler<SendShortMessageEvent>
    {
        private readonly ILogger<SendShortMessageEventHandler> logger;
        private readonly IRepository<User> userRepository;

        public SendShortMessageEventHandler(ILogger<SendShortMessageEventHandler> logger
            , IRepository<User> userRepository
            )
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public async Task Handle(SendShortMessageEvent @event)
        {
            int uid = @event.UserId;
            var user = await userRepository.FindAsync(u => u.Id == uid);
            //如果用户发短信字段为false没有发短信，就发短信
            //if (user.)
            //{
                logger.LogInformation($"给用户{uid}；名称:{user.Name}成功发送短信");
            //}
            //已经发了短信了，不做处理
        }
    }
}
