using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 内容管理
    /// </summary>
    public class ContentManagerController : Controller
    {
        // GET: Admin/ContentManager
        public ActionResult Index()
        {
            return View();
        }
    }
}