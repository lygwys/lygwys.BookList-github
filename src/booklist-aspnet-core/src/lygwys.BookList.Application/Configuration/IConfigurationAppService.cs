using System.Threading.Tasks;
using lygwys.BookList.Configuration.Dto;

namespace lygwys.BookList.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
