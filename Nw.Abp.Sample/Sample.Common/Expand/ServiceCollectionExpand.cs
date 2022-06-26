using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisHelper.Interface;
using RedisHelper.Service;
using Sample.Common.JwtHelpers;
using Sample.Common.RabbitMQ;
using Sample.Common.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public static class ServiceCollectionExpand
    {
        /// <summary>
        /// 配置文件Redis配置对象注入到容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedisConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RedisConfigure>(config.GetSection(RedisConfigure.Key));

            return services;
        }

        /// <summary>
        /// 配置文件RabbitMQ配置对象注入到容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddRabbitMQConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RabbitMQConfigure>(config.GetSection(RabbitMQConfigure.Key));

            return services;
        }

        /// <summary>
        /// 配置文件JWT配置对象注入到容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddJwtConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtConfigure>(config.GetSection(JwtConfigure.AppKey));

            return services;
        }

        /// <summary>
        /// 添加redis服务到容器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedisService(this IServiceCollection services)
        {
            services.AddTransient<IRedisConfigureHelper, RedisConfigureHelper>();
            services.AddTransient<IRedisPersistentConnection, DefaultRedisPersistentConnection>();
            services.AddTransient<RedisHashService>();
            services.AddTransient<RedisListService>();
            services.AddTransient<RedisStringService>();
            services.AddTransient<RedisZSetService>();
            return services;
        }
    }
}
