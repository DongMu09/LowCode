using Volo.Abp.Modularity;

namespace LowCode
{
    [DependsOn(
        typeof(LowCodeApplicationModule),
        typeof(LowCodeDomainTestModule)
        )]
    public class LowCodeApplicationTestModule : AbpModule
    {

    }
}