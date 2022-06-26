using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Sample.Common.JwtHelpers.IServices;
using Sample.Common.JwtHelpers.Services;
using Sample.Domain.Expand;
using System;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Sample.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpAutofacModule)
        )]
    public class SampleDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ContainerBuilder containerBuilder = context.Services.GetContainerBuilder();
            containerBuilder.RegisterService();
        }
    }
}
