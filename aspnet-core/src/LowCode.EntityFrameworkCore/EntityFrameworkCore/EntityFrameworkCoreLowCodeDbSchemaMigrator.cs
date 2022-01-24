using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LowCode.Data;
using Volo.Abp.DependencyInjection;

namespace LowCode.EntityFrameworkCore
{
    public class EntityFrameworkCoreLowCodeDbSchemaMigrator
        : ILowCodeDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLowCodeDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LowCodeDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LowCodeDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
