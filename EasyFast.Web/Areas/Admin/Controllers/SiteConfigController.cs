using EasyFast.Application.Config;
using EasyFast.Application.Config.Dto;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class SiteConfigController : EasyFastControllerBase
    {
        #region 依赖注入
        private ISiteConfigAppService _siteConfigAppService;
        public SiteConfigController(ISiteConfigAppService siteConfigAppService)
        {
            _siteConfigAppService = siteConfigAppService;
        }
        #endregion


        public ActionResult SiteInfo()
        {
            var data = _siteConfigAppService.GetSiteInfo();
            return View(data);
        }

        [HttpPost]
        public ActionResult SiteInfo(SiteInfoDto model)
        {
            _siteConfigAppService.UpdateSiteInfo(model);
            return Json(model);
        }

        public ActionResult SiteOption()
        {
            var data = _siteConfigAppService.GetSiteOption();
            return View(data);
        }

        [HttpPost]
        public JsonResult SiteOption(SiteOptionDto model)
        {
            _siteConfigAppService.UpdateSiteOption(model);
            return Json(model);
        }
    }
}