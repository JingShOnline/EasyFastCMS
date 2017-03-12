using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class ModelController : EasyFastControllerBase
    {
        // GET: Admin/Model
        public ActionResult Index()
        {
            return View();
        }
    }
}