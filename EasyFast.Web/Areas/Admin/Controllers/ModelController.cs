using EasyFast.Application.ContentModel.ModelRecord;
using EasyFast.Application.Model;
using EasyFast.Application.Model.Dto;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    public class ModelController : EasyFastControllerBase
    {
        // GET: Admin/Model
        private readonly IModelAppService _modelAppService;

        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }


        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateModel()
        {
            ViewBag.ActionName = "添加内容模型";
            return PartialView("CreateOrUpdateModel", new ModelDto());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EditModel(int id)
        {
            ViewBag.ActionName = "修改内容模型";
            var model = await _modelAppService.GetAsync(id);
            return PartialView("CreateOrUpdateModel", model);
        }
    }
}