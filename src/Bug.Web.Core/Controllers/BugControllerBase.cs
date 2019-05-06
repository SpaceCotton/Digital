using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Bug.Controllers
{
    public abstract class BugControllerBase: AbpController
    {
        protected BugControllerBase()
        {
            LocalizationSourceName = BugConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
