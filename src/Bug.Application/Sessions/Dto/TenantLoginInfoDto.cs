using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bug.MultiTenancy;

namespace Bug.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
