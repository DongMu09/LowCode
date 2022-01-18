using System.Threading.Tasks;

namespace LowCode.Data
{
    public interface ILowCodeDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
