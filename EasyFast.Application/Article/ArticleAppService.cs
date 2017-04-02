using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Article.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using Abp.AutoMapper;
using EasyFast.Common;
using EasyFast.Core;

namespace EasyFast.Application.Article
{
    /// <summary>
    /// 文章内容资源
    /// </summary>
    public class ArticleAppService : ApplicationService, IArticleAppService
    {
        private readonly IRepository<Content_Article> _articleRepository;

        public ArticleAppService(IRepository<Content_Article> articleRepository)
        {
            _articleRepository = articleRepository;

        }



        public async Task AddOrUpdateAsync(ArticleDto dto)
        {
            //截断出正文中的内容添加到导读中
            if (string.IsNullOrWhiteSpace(dto.Info))
                dto.Guide = dto.Content.Substring(0, (int)Math.Ceiling(dto.Content.Length * 0.3));
            await _articleRepository.InsertOrUpdateAsync(dto.MapTo<Content_Article>());
        }



        public async Task<ArticleDto> GetAsync(int id)
        {
            var model = await _articleRepository.GetAsync(id);

            return model.MapTo<ArticleDto>();
        }
    }
}
