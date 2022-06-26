using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sample.Application;
using Sample.Common;
using Sample.Common.JwtHelpers;
using Sample.Common.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sample.AuthCenterApi
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(SampleApplicationModule),
        typeof(AbpAutofacModule)
        )]
    public class SampleAuthCenterApiModule : AbpModule
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.AuthCenterApi", Version = "v1" });
            });

            services.AddJwtConfig(Configuration);


        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();

            app.UseRequesEnableBufferingMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.AuthCenterApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
