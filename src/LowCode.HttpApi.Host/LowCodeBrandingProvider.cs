using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LowCode
{
    [Dependency(ReplaceServices = true)]
    public class LowCodeBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LowCode";
    }
}
