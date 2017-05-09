using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using EasyFast.Core.Authorization;
using EasyFast.Application.MultiTenancy;
using WebGrease.Css;

namespace EasyFast.Web.Controllers
{
    [AbpMvcAuthorize(Roles = PermissionNames.Pages_Tenants)]
    public class TenantsController : EasyFastControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}