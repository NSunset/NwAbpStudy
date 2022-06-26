using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sample.Application;
using Sample.Common;
using Sample.Common.JwtHelpers;
using Sample.Common.Middleware;
using Sample.Domain.Expand;
using Sample.HttpApi.Unitily;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sample.HttpApi
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreModule),
        typeof(SampleApplicationModule)
        )]
    public class SampleHttpApiModule : AbpModule
    {
        public static IConfiguration Configuration { get; set; }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            IServiceCollection services = context.Services;
            services.AddControllers(options =>
            {
                options.Filters.Add<SampleExceptionFilterAttribute>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.HttpApi", Version = "v1" });
            });
            //base.ConfigureServices(context);


            JwtConfigure jwtConfigure = new JwtConfigure();
            Configuration.GetSection(JwtConfigure.AppKey).Bind(jwtConfigure);

            //使用JWT认证权限
            services.AddRSJwtAuthentication(jwtConfigure);

            #region 自定义授权逻辑策略
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CustomPolicy", policy =>
                {
                    policy.Requirements.Add(new NameRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, CustomNameAuthorizationHandler>();
            #endregion

            #region 添加配置文件对象到容器
            //redis
            services.AddRedisConfig(Configuration);

            //rabbitmq
            services.AddRabbitMQConfig(Configuration);
            #endregion


            //注册redis服务到容器
            services.AddRedisService();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            IApplicationBuilder app = context.GetApplicationBuilder();
            IWebHostEnvironment env = context.GetEnvironment();

            app.UseRequesEnableBufferingMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.HttpApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //初始化RabbitMQ消费端
            app.Subscribe();
        }
    }
}
