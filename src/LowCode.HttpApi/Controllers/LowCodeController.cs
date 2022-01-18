using LowCode.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LowCode.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LowCodeController : AbpControllerBase
    {
        protected LowCodeController()
        {
            LocalizationResource = typeof(LowCodeResource);
        }
    }
}