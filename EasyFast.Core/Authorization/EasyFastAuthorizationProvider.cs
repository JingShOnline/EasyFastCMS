using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace EasyFast.Core.Authorization
{
    public class EasyFastAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ??
                        context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //user permissions
            var role = pages.CreateChildPermission(PermissionNames.PagesRole, L(PermissionNames.PagesRole));
            role.CreateChildPermission(PermissionNames.PagesRoleCreate, L(PermissionNames.PagesRoleCreate));
            role.CreateChildPermission(PermissionNames.PagesRoleEdit, L(PermissionNames.PagesRoleEdit));
            role.CreateChildPermission(PermissionNames.PagesRoleDelete, L(PermissionNames.PagesRoleDelete));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EasyFastConsts.LocalizationSourceName);
        }
    }
}
