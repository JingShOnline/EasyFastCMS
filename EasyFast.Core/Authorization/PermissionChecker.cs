using Abp.Authorization;
using EasyFast.Core.Authorization.Roles;
using EasyFast.Core.MultiTenancy;
using EasyFast.Core.Users;

namespace EasyFast.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
