﻿using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Abp.Threading;
using EasyFast.Web.Controllers;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
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
            return View();
        }

        public ActionResult Navigation(string currentPageName)
        {
            var model = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("AdminMenu", AbpSession.ToUserIdentifier()));
            ViewBag.CurrentPageName = currentPageName;
            return PartialView("~/Areas/Admin/Views/Shared/_navigation.cshtml", model);
        }
    }
}