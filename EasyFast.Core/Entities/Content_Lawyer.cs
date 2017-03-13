using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Core.Entities
{
    public class Content_Lawyer : Entity
    {
        /// <summary>
        /// 头像url地址
        /// </summary>
        [StringLength(200)]
        public string Avatar { get; set; }

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
        /// 导读
        /// </summary>
        [StringLength(500)]
        public string Guide { get; set; }

        /// <summary>
        /// 模型内容
        /// </summary>
        public string Content { get; set; }
    }
}
