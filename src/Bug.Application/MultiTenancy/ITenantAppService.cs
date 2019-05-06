using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bug.MultiTenancy.Dto;

namespace Bug.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
