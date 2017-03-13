using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Core.Entities
{
    public class Content_Article : Entity
    {
        public int ColumnId { get; set; }
        public virtual Column Column { get; set; }

        /// <summary>
        /// 导读
        /// </summary>
        [StringLength(500)]
        public string Guide { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
    }
}
