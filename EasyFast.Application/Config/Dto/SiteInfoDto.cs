using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Config.Dto
{
    [AutoMap(typeof(SiteConfig))]
    public class SiteInfoDto : EntityDto
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        [StringLength(50)]
        public string SiteName { get; set; }

        /// <summary>
        /// 网站标题
        /// </summary>
        [StringLength(50)]
        public string SiteTitle { get; set; }

        /// <summary>
        /// 网站地址
        /// </summary>
        [StringLength(50)]
        public string SiteUrl { get; set; }

        /// <summary>
        /// Logo地址
        /// </summary>
        [StringLength(50)]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Banner地址
        /// </summary>
        [StringLength(50)]
        public string BannerUrl { get; set; }

        /// <summary>
        /// 网站站长
        /// </summary>
        [StringLength(50)]
        public string Webmaster { get; set; }

        /// <summary>
        /// 站长邮箱
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 网站版权信息
        /// </summary>
        [StringLength(50)]
        public string CopyRitht { get; set; }

        /// <summary>
        /// META关键词
        /// </summary>
        [StringLength(50)]
        public string Keywords { get; set; }

        /// <summary>
        /// META描述
        /// </summary>
        [StringLength(50)]
        public string Description { get; set; }
    }
}
