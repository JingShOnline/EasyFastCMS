using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }
    }
}