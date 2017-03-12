using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.MultiTenancy;

namespace EasyFast.Application.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}