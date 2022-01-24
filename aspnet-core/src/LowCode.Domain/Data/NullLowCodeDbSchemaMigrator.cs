using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LowCode.Data
{
    /* This is used if database provider does't define
     * ILowCodeDbSchemaMigrator implementation.
     */
    public class NullLowCodeDbSchemaMigrator : ILowCodeDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}