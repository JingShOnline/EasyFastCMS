using Abp.Web.Security.AntiForgery;
using EasyFast.Application.Content.Dto;
using EasyFast.Application.Upload;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using EasyFast.Application.Content;
using EasyFast.Application.Upload.Dto;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 信息管理
    /// </summary>
    [AbpMvcAuthorize]
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
        public ActionResult AddContent(int columnId, int modelId, string ctrl, string columnName)
        {
            ViewBag.ctrl = ctrl;
            ViewBag.columnName = Server.UrlDecode(columnName);
            ViewBag.action = "AddContent";
            return View(new AddContentDto() { ColumnId = columnId, ModelId = modelId });
        }

        /// <summary>
        /// 转到修改内容页
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UpdateContent(int id, string ctrl, string columnName)
        {
            var dto = await _contentAppService.GetContent(id);
            ViewBag.ctrl = ctrl;
            ViewBag.columnName = Server.UrlDecode(columnName);
            ViewBag.action = "UpdateContent";
            return View("AddContent", dto);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> UploadFile(WebUploadDto dto)
        {
            var path = await _uploadFlieAppService.UploadImg(Path.GetExtension(dto.File.FileName), dto.ColumnName, dto.Width, dto.Height, dto.Dir, dto.File);

            return Json(path);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ContentResult> EditorUploadFile()
        {
            var file = Request.Files;
            var dir = Request["dir"];
            var columnName = Request["columnName"];
            var path = await _uploadFlieAppService.UploadImg(Path.GetExtension(file[0].FileName), columnName, null, null, dir, file[0]);
            return Content(path);
        }
    }
}