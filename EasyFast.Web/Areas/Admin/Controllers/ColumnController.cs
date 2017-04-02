using Abp.Web.Models;
using EasyFast.Application.Column;
using EasyFast.Application.Column.Dto;
using EasyFast.Web.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.AutoMapper;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
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

        /// <summary>
        /// 转到新建单页节点页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSingle()
        {
            ViewBag.SingleTitle = "新建单页节点";
            var model = new SingleColumnDto();
            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> AddOrUpdateSingle(SingleColumnDto model)
        {
            await _columnAppService.AddOrUpdateSingleAsync(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });

        }

        [HttpPost]
        [DontWrapResult]
        public async Task<JsonResult> GetTreeGrid(TreeGridInput search)
        {
            var list = await _columnAppService.GetTreeGrid(search);
            return Json(list);
        }


        /// <summary>
        /// 转到新建栏目页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddColumn()
        {
            ViewBag.ColumnTitle = "新建栏目";
            var model = new ColumnDto();
            return View(model);
        }

        /// <summary>
        /// 获取树形栏目名称结构
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetTreeColumnName()
        {
            var data=await _columnAppService.GetTreeColumnNameAsync();
            return Json(data);
        }



        /// <summary>
        /// 转到修改栏目页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateColumn(int id)
        {

            var model = await _columnAppService.GetColumnAsync<ColumnDto>(id);
            if (model.ColumnTypeEnum == Core.Entities.ColumnTypeEnum.Normal)
            {
                ViewBag.ColumnTitle = "修改栏目";
                return View("AddColumn", model);
            }
            var singleDto = model.MapTo<SingleColumnDto>();

            ViewBag.ColumnTitle = "修改单页节点";
            return View("AddSingle", singleDto);


        }


        /// <summary>
        /// 添加或修改栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddOrUpdateColumn(ColumnDto model)
        {
            await _columnAppService.AddOrUpdateColumn(model);
            return Json(new AjaxResponse { TargetUrl = "Index" });
        }
    }

}