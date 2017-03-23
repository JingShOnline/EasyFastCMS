using EasyFast.Application.Config;
using EasyFast.Application.Config.Dto;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<ActionResult> SiteInfo()
        {
            var data = await _siteConfigAppService.GetSiteConfig();
            return View(data);
        }


        public async Task<ActionResult> SiteOption()
        {
            var data = await _siteConfigAppService.GetSiteConfig();
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSiteConfig(SiteConfigDto dto)
        {
            await _siteConfigAppService.UpdateSiteConfig(dto);
            return Json(dto);
        }


    }
}