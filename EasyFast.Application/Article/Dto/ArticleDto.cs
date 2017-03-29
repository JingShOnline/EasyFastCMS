using Abp.AutoMapper;
using EasyFast.Application.Content.Dto;
using EasyFast.Application.Model.Dto;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class ArticleDto : AddContentDto
    {

        [DisplayName("文章标题")]
        [Required(ErrorMessage = "请输入文章标题")]
        public override string Title { get; set; }

        [DisplayName("文章列表图片")]
        [Required(ErrorMessage = "请上传列表小图")]
        public override string DefaultPicUrl { get; set; }

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
        [Required(ErrorMessage = "请输入文章内容")]
        public string Content { get; set; }
    }
}
