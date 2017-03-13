using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Core.Entities
{
    public class Model : Entity
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 对应数据库表名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
