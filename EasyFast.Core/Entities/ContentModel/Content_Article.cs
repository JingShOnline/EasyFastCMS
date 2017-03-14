using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Abp.Domain.Entities.Auditing;

namespace EasyFast.Core.Entities.ContentModel
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
        public string FullTitle { get; set; }

        /// <summary>
        /// 二级标题
        /// </summary>
        public string ShortTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
