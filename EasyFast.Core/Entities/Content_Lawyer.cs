using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFast.Core.Entities
{
    /// <summary>
    /// 律师模型
    /// </summary>
    [Table("Content_Lawyer")]
    public class Content_Lawyer : Common_Model
    {
        /// <summary>
        /// 职位
        /// </summary>
        [StringLength(50)]
        public string Position { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(50)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 律师详细介绍
        /// </summary>
        public string Content { get; set; }
    }
}
