using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using lygwys.BookList.Configuration.Dto;

namespace lygwys.BookList.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookListAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
