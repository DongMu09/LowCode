using System;
using System.Collections.Generic;
using System.Text;
using LowCode.Localization;
using Volo.Abp.Application.Services;

namespace LowCode
{
    /* Inherit your application services from this class.
     */
    public abstract class LowCodeAppService : ApplicationService
    {
        protected LowCodeAppService()
        {
            LocalizationResource = typeof(LowCodeResource);
        }
    }
}
