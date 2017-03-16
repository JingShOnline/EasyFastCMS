using Abp.Application.Services.Dto;
using EasyFast.Application.Article;
using EasyFast.Application.Article.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 文章内容_控制器
    /// </summary>
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        public ActionResult AddContent()
        {
            return PartialView(new ArticleDto());
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task DeleteAsync(int id)
        {
            await _articleAppService.DeleteAsync(id);
        }

    }
}