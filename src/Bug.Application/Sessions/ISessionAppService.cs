using System.Threading.Tasks;
using Abp.Application.Services;
using Bug.Sessions.Dto;

namespace Bug.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
