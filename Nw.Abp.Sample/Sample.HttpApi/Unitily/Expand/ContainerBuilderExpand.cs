using Autofac;
using EventBus;
using EventBus.Abstractions;
using EventBusRabbitMQ;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Sample.Common.RabbitMQ;
using Sample.Domain.Users.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.HttpApi.Unitily.Expand
{
    public static class ContainerBuilderExpand
    {
        public static ContainerBuilder RegisterService(this ContainerBuilder builder)
        {
            #region RabbitMQ服务注入到容器
            builder.RegisterType<InMemoryEventBusSubscriptionsManager>().As<IEventBusSubscriptionsManager>().SingleInstance();

            builder.Register<IRabbitMQPersistentConnection>(context =>
            {
                RabbitMQConfigure rabbitMQConfigure = context.Resolve<IOptions<RabbitMQConfigure>>().Value;

                var logger = context.Resolve<ILogger<DefaultRabbitMQPersistentConnection>>();

                IConnectionFactory connectionFactory = new ConnectionFactory
                {
                    HostName = rabbitMQConfigure.HostName,
                    VirtualHost = rabbitMQConfigure.VirtualHost,
                    UserName = rabbitMQConfigure.UserName,
                    Password = rabbitMQConfigure.Password,
                    DispatchConsumersAsync = true
                };
                return new DefaultRabbitMQPersistentConnection(
                    connectionFactory,
                    logger,
                    rabbitMQConfigure.RetryCount
                    );
            }).SingleInstance();

            builder.Register<IEventBus>(context =>
            {
                RabbitMQConfigure rabbitMQConfigure = context.Resolve<IOptions<RabbitMQConfigure>>().Value;

                IRabbitMQPersistentConnection rabbitMQPersistent = context.Resolve<IRabbitMQPersistentConnection>();

                var logger = context.Resolve<ILogger<EventBusRabbitMQ.EventBusRabbitMQ>>();

                var aotofacScope = context.Resolve<ILifetimeScope>();

                var subscriptionManger = context.Resolve<IEventBusSubscriptionsManager>();

                return new EventBusRabbitMQ.EventBusRabbitMQ(
                    rabbitMQPersistent,
                    logger,
                    aotofacScope,
                    subscriptionManger,
                    rabbitMQConfigure.BrokerName,
                    rabbitMQConfigure.QueueName,
                    rabbitMQConfigure.RetryCount
                    );
            }).SingleInstance();

            builder.RegisterType<SendShortMessageEventHandler>();
            #endregion

            return builder;
        }
    }
}
