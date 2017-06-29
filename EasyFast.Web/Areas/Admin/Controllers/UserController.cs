using EasyFast.Web.Controllers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using EasyFast.Application.Authorization.Permissions;
using EasyFast.Application.Authorization.Roles;
using EasyFast.Core.Authorization;
using EasyFast.Web.Areas.Admin.Models.Roles;

namespace EasyFast.Web.Areas.Admin.Controllers
{

    [AbpMvcAuthorize]
    public class UserController : EasyFastControllerBase
    {

        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionAppService _permissionAppService;

        public UserController(IPermissionAppService permissionAppService, IRoleAppService roleAppService)
        {
            _permissionAppService = permissionAppService;
            _roleAppService = roleAppService;
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 管理员管理
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminList()
        {
            return View();
        }

        /// <summary>
        /// 会员管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            return View();
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        //[AbpMvcAuthorize(Roles = PermissionNames.PagesRole)]
        public ActionResult RoleList()
        {
            var permissions = _permissionAppService.GetAllPermissions()
                                                    .Items
                                                    .Select(p => new ComboboxItemDto(p.Name, new string('-', p.Level * 2) + " " + p.DisplayName))
                                                    .ToList();

            permissions.Insert(0, new ComboboxItemDto("", ""));
            var model = new RoleListViewModel
            {
                Permissions = permissions
            };

            return View(model);
        }


        //[AbpMvcAuthorize(PermissionNames.PagesRoleCreate, PermissionNames.PagesRoleEdit)]
        public async Task<PartialViewResult> CreateOrEditRoleModal(int? id)
        {
            var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            var viewModel = new CreateOrEditRoleModalViewModel(output);

            return PartialView("_CreateOrEditRoleModal", viewModel);
        }
    }
}