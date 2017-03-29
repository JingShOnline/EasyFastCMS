using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Article.Dto
{
    /// <summary>
    /// 文章列表返回模型
    /// </summary>
    [AutoMapFrom(typeof(Content_Article))]
    public class ArticleListOutput : EntityDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 导读
        /// </summary>
        public string Guide { get; set; }

        /// <summary>
        /// 列表图
        /// </summary>
        public string DefaultPicUrl { get; set; }
    }
}
