using Microsoft.Extensions.DependencyInjection;
using Sample.EntityFrameworkCore.Data;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Sample.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule)
        )]
    public class SampleEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            IServiceCollection service = context.Services;

            service.AddAbpDbContext<CustomDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(opts =>
                {
                    opts.DbContextOptions.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking);

                    opts.UseMySQL();
                });
            });

           
            //base.ConfigureServices(context);
        }
    }
}
