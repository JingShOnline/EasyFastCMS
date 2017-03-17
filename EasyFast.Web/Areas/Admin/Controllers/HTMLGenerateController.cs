using EasyFast.Web.Controllers;
using System.Collections.Generic;
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
        /// 根据选择的栏目id生成首页静态文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult ColumnIndexGnerate(List<int> ids)
        {

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