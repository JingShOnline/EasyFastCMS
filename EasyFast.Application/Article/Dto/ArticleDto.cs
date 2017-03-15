using Abp.AutoMapper;
using EasyFast.Application.Model.Dto;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Article.Dto
{
    /// <summary>
    /// 文章Dto
    /// </summary>
    [AutoMap(typeof(Content_Article))]
    public class ArticleDto : ModelDto
    {
        /// <summary>
        /// 标题全称
        /// </summary>
        [StringLength(50)]
        public string FullTitle { get; set; }

        /// <summary>
        /// 二级标题
        /// </summary>
        [StringLength(25)]
        public string ShortTitle { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
    }
}
