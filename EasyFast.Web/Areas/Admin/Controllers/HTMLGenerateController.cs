using EasyFast.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{

    [AbpMvcAuthorize]
    public class HtmlGenerateController : EasyFastControllerBase
    {
        /// <summary>
        /// 生成首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 生成内容页
        /// </summary>
        /// <returns></returns>
        public ActionResult Content()
        {
            return View();
        }



        /// <summary>
        /// 生成列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 清理静态文件
        /// </summary>
        /// <returns></returns>
        public ActionResult CleanStaticFile()
        {
            return View();
        }
    }
}