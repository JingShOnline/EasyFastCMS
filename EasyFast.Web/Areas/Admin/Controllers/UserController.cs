using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class UserController : EasyFastControllerBase
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 管理员管理
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminList()
        {
            return View();
        }

        /// <summary>
        /// 会员管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            return View();
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            return View();
        }
    }
}