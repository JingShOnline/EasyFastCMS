using Abp.Application.Services;
using EasyFast.Application.Article.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Article
{
    /// <summary>
    /// 文章资源 
    /// </summary>
    public interface IArticleAppService : IApplicationService
    {

      
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddArticle(ArticleDto dto);

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateArticle(ArticleDto dto);

        /// <summary>
        /// 添加或修改文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddOrUpdateArticle(ArticleDto dto);

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteArticle(int id);
    }
}
