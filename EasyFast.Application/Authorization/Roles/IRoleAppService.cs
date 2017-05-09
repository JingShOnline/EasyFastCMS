using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EasyFast.Application.Authorization.Roles.Dto;

namespace EasyFast.Application.Authorization.Roles
{
    /// <summary>
    /// 角色应用服务
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);

        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<RoleListDto>> GetRoles(GetRolesInput input);

        /// <summary>
        /// 获取角色用于修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input);

        /// <summary>
        /// 添加或更新角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateRole(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteRole(EntityDto input);
    }
}
