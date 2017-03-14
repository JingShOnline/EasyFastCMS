using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class HTMLGenerateController : EasyFastControllerBase
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
        /// 生成单页节点
        /// </summary>
        /// <returns></returns>
        public ActionResult Single()
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
    }
}