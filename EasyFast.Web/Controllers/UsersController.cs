using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using EasyFast.Application.Authorization.Users;
using EasyFast.Core.Authorization;

namespace EasyFast.Web.Controllers
{
    [AbpMvcAuthorize(Roles = PermissionNames.Pages_Users)]
    public class UsersController : EasyFastControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}