using Abp.Application.Services.Dto;
using EasyFast.Application.Article;
using EasyFast.Application.Article.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Threading;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 文章内容_控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        /// <summary>
        /// 转到添加文章页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddContent()
        {
            return PartialView(new ArticleDto());
        }

        /// <summary>
        /// 转到更新文章页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateContent(int id)
        {
            var model = AsyncHelper.RunSync(() => _articleAppService.GetAsync(id));


            return PartialView("AddContent", model);
        }

    }
}