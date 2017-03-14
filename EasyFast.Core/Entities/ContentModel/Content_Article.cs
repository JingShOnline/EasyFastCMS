using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFast.Core.Entities
{
    /// <summary>
    /// 文件内容模型
    /// </summary>
    [Table("Content_Article")]
    public class Content_Article : Common_Model
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
