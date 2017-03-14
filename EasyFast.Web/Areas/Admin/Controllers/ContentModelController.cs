using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyFast.Application.ContentModel.ModelRecord;
using EasyFast.Application.ContentModel.ModelRecord.Dto;
using EasyFast.Web.Controllers;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 内容模型控制器
    /// </summary>
    public class ContentModelController : EasyFastControllerBase
    {


        private readonly IModelRecordAppService _modelRecordAppService;

        public ContentModelController(IModelRecordAppService modelRecordAppService)
        {
            _modelRecordAppService = modelRecordAppService;
        }


        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateModal()
        {
            ViewBag.ActionName = "添加内容模型";
            return PartialView("CreateOrUpdateModal", new ModelRecordDto());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EditModal(int id)
        {
            ViewBag.ActionName = "修改内容模型";
            var model = await _modelRecordAppService.GetAsync(id);
            return PartialView("CreateOrUpdateModal", model);
        }


    }
}