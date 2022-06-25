using Microsoft.Extensions.DependencyInjection;
using Sample.Common.JwtHelpers.IServices;
using Sample.Common.JwtHelpers.Services;
using System;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Sample.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class SampleDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<IJwtService, DefaultRsJwtService>();
        }
    }
}
