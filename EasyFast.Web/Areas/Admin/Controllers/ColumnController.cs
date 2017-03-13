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

        #region 新增栏目/单页栏目
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
            ColumnDto model = new ColumnDto();
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(ColumnDto model)
        {
            _columnAppService.Add(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });

        }
        #endregion

        #region 编辑栏目/单页栏目
        public ActionResult UpdateSingle(int id)
        {
            SingleColumnDto model = _columnAppService.FindSingle(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateSingle(SingleColumnDto model)
        {
            _columnAppService.UpdateSingle(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });
        }

        public ActionResult Update(int id)
        {
            ColumnDto model = _columnAppService.Find(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult Update(ColumnDto model)
        {
            _columnAppService.Update(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });
        }
        #endregion



    }
}