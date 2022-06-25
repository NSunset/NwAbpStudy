using Sample.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Sample.Repositories
{
    [DependsOn(
        typeof(SampleEntityFrameworkCoreModule)
        )]
    public class SampleRepositoriesModule : AbpModule
    {

    }
}
