using System.Threading.Tasks;
using Abp.Application.Services;
using Bug.Authorization.Accounts.Dto;

namespace Bug.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
