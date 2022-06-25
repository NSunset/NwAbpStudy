using Sample.EntityFrameworkCore;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Application
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(SampleEntityFrameworkCoreModule),
        typeof(AbpAutoMapperModule)
        )]
    public class SampleApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SampleApplicationAutoMapperProfile>();
            });
        }
    }
}
