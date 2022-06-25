using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace Sample.IApplication
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
        )]
    public class SampIApplicationModule : AbpModule
    {
    }
}
