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

namespace EasyFast.Application.Article
{
    /// <summary>
    /// 文章资源
    /// </summary>
    public class ArticleAppService : ApplicationService, IArticleAppService
    {
        private readonly IRepository<Content_Article> _articleRepository;

        public ArticleAppService(IRepository<Content_Article> articleRepository)
        {
            this._articleRepository = articleRepository;
        }


        public async Task AddArticle(ArticleDto dto)
        {
            await _articleRepository.InsertAsync(dto.MapTo<Content_Article>());
        }

        public async Task AddOrUpdateArticle(ArticleDto dto)
        {
            if (dto.Id == 0)
                await AddArticle(dto);
            else
                await UpdateArticle(dto);
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.DeleteAsync(id);
        }

        public async Task UpdateArticle(ArticleDto dto)
        {
            var model = await _articleRepository.GetAsync(dto.Id);
            dto.MapTo(model);
            await _articleRepository.UpdateAsync(model);
        }
    }
}
