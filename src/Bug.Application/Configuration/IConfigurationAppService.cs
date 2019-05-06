using System.Threading.Tasks;
using Bug.Configuration.Dto;

namespace Bug.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
