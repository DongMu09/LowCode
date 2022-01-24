using Volo.Abp.Settings;

namespace LowCode.Settings
{
    public class LowCodeSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LowCodeSettings.MySetting1));
        }
    }
}
