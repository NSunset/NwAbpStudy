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
    }
}
