using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using EasyFast.Core.Authorization;
using EasyFast.Application.MultiTenancy;

namespace EasyFast.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
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