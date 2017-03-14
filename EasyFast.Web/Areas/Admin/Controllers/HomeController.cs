using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Abp.Threading;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class HomeController : EasyFastControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;

        public HomeController(IUserNavigationManager userNavigationManager)
        {
            _userNavigationManager = userNavigationManager;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Menu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("AdminMenu", AbpSession.ToUserIdentifier()));
            return View();
        }

        public ActionResult Navigation()
        {
            var model = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("AdminMenu", AbpSession.ToUserIdentifier()));
            return PartialView("~/Areas/Admin/Views/Shared/_navigation.cshtml", model);
        }
    }
}