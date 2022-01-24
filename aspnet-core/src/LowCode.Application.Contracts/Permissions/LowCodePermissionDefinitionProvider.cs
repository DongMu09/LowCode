using LowCode.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LowCode.Permissions
{
    public class LowCodePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LowCodePermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(LowCodePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LowCodeResource>(name);
        }
    }
}
