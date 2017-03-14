using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace EasyFast.Core.Entities
{
    public class SiteConfig : Entity
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


        /// <summary>
        /// 租户Id
        /// </summary>
        public int TenantId { get; set; }
    }
}
