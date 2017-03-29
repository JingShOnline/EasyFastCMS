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
    /// 文章内容资源 
    /// </summary>
    public interface IArticleAppService : IApplicationService
    {


        /// <summary>
        /// 添加或修改文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddOrUpdateAsync(ArticleDto dto);



        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleDto> GetAsync(int id);
    }
}
