using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Bug.Configuration.Dto;

namespace Bug.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BugAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
