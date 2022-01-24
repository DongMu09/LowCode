using LowCode.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LowCode
{
    [DependsOn(
        typeof(LowCodeEntityFrameworkCoreTestModule)
        )]
    public class LowCodeDomainTestModule : AbpModule
    {

    }
}