using System.Threading.Tasks;
using Abp.Application.Services;
using EasyFast.Application.Roles.Dto;

namespace EasyFast.Application.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
