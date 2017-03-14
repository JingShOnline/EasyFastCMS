using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFast.Core.Entities.ContentModel
{
    /// <summary>
    /// 律师模型
    /// </summary>
    [Table("Content_lawyer")]
    public class Content_Lawyer : Common_Model
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 办事处
        /// </summary>
        public string Bureaux { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 律师详细介绍
        /// </summary>
        public string Content { get; set; }
    }
}
