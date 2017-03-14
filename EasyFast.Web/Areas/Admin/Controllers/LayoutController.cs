using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Abp.Threading;
using Abp.Web.Mvc.Controllers;
using EasyFast.Web.Controllers;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class LayoutController : EasyFastControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;

        public LayoutController(IUserNavigationManager userNavigationManager)
        {
            _userNavigationManager = userNavigationManager;
        }

        public ActionResult Navigation()
        {
            var menu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("AdminMenu", AbpSession.ToUserIdentifier()));
            return PartialView("~/Areas/Admin/Views/Shared/_navigation.cshtml", menu);
        }
    }
}