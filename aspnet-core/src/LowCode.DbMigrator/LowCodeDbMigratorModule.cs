using LowCode.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LowCode.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LowCodeEntityFrameworkCoreModule),
        typeof(LowCodeApplicationContractsModule)
        )]
    public class LowCodeDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
