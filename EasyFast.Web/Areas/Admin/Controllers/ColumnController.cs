using Abp.Web.Models;
using EasyFast.Application.Column;
using EasyFast.Application.Column.Dto;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class ColumnController : EasyFastControllerBase
    {
        #region 依赖注入
        private IColumnAppService _columnAppService;
        public ColumnController(IColumnAppService columnAppService)
        {
            _columnAppService = columnAppService;
        }
        #endregion

        // GET: Admin/Column
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [DontWrapResult]
        public JsonResult GetTreeGrid(TreeGridInput search)
        {
            var list = _columnAppService.GetTreeGrid(search);
            return Json(list);
        }

        public ActionResult AddSingle()
        {
            SingleColumnDto model = new SingleColumnDto();
            return View(model);
        }

        [HttpPost]
        public JsonResult AddSingle(SingleColumnDto model)
        {
            _columnAppService.AddSingle(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });

        }

        public ActionResult Add()
        {
            return View();
        }
    }
}