using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EasyFast.Application.Authorization.Permissions.Dto;

namespace EasyFast.Application.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
