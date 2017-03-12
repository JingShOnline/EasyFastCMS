using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.MultiTenancy;

namespace EasyFast.Application.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantListDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}