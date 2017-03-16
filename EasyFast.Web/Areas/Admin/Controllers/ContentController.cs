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

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 信息管理
    /// </summary>
    public class ContentController : Controller
    {

        private readonly IUploadFileAppService _uploadFlieAppService;

        public ContentController(IUploadFileAppService uploadFileAppService)
        {
            _uploadFlieAppService = uploadFileAppService;
        }

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 转到添加内容页
        /// </summary>
        /// <param name="controller">具体内容控制器</param>
        /// <returns></returns>
        public ActionResult AddContent(int columnId, int modelId, string ctrl, string modelName)
        {
            ViewBag.ctrl = ctrl;
            ViewBag.modelName = Server.UrlDecode(modelName);
            return View(new AddContentDto() { ColumnId = columnId, ModelId = modelId });
        }

        /// <summary>
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