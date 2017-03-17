using Abp.Web.Security.AntiForgery;
using EasyFast.Application.Content.Dto;
using EasyFast.Application.Upload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyFast.Application.Content;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 信息管理
    /// </summary>
    public class ContentController : Controller
    {

        private readonly IUploadFileAppService _uploadFlieAppService;

        private readonly IContentAppService _contentAppService;

        public ContentController(IUploadFileAppService uploadFileAppService, IContentAppService contentAppService)
        {
            _uploadFlieAppService = uploadFileAppService;
            _contentAppService = contentAppService;
        }

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 转到添加内容页
        /// </summary>
        /// <returns></returns>
        public ActionResult AddContent(int columnId, int modelId, string ctrl, string modelName)
        {
            ViewBag.ctrl = ctrl;
            ViewBag.modelName = Server.UrlDecode(modelName);
            ViewBag.action = "AddContent";
            return View(new AddContentDto() { ColumnId = columnId, ModelId = modelId });
        }

        /// <summary>
        /// 转到修改内容页
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UpdateContent(int id, string ctrl, string modelName)
        {
            var dto = await _contentAppService.GetContent(id);
            ViewBag.ctrl = ctrl;
            ViewBag.modelName = Server.UrlDecode(modelName);
            ViewBag.action = "UpdateContent";
            return View("AddContent", dto);
        }

        /// <summary>S
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> UploadFile(string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file, string modelName)
        {
            var path = await _uploadFlieAppService.UploadImg(Path.GetExtension(name), modelName, file);

            return Json(path);
        }


    }
}