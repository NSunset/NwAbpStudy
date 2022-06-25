using Sample.EntityFrameworkCore;
using Sample.IApplication;
using Sample.Repositories;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Application
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(SampleRepositoriesModule),
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
