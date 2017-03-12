using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using EasyFast.Core.Entities;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Application.Config.Dto
{
    [AutoMap(typeof(SiteConfig))]
    public class SiteOptionDto : EntityDto
    {
        /// <summary>
        /// HTML生成目录，留空表示生成在根目录下
        /// </summary>
        [StringLength(50)]
        public string HTMLDir { get; set; }

        /// <summary>
        /// 模板目录
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TemplateDir { get; set; }

        /// <summary>
        /// 标签库目录，必须在模板目录中。
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TagDir { get; set; }

        /// <summary>
        /// 分页标签库目录，必须在模板目录中。
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PageDir { get; set; }

        /// <summary>
        /// 代码段库目录，必须在模板目录中。
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CodeDir { get; set; }
    }
}
