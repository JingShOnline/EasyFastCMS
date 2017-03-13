using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Core.Entities
{
    public class CommonTitle : Entity
    {
        /// <summary>
        /// 对应栏目
        /// </summary>
        public int ColumnId { get; set; }
        public virtual Column Column { get; set; }

        /// <summary>
        /// 内容模型Id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 对应模型，非单页栏目必选模型
        /// </summary>
        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 完整标题
        /// </summary>
        [StringLength(500)]
        public string FullTitle { get; set; }

        /// <summary>
        /// 简要标题
        /// </summary>
        [StringLength(100)]
        public string ShortTitle { get; set; }

        /// <summary>
        /// 总点击数
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// 日点击数
        /// </summary>
        public int DayHits { get; set; }

        /// <summary>
        /// 周点击数
        /// </summary>
        public int WeekHits { get; set; }

        /// <summary>
        /// 月点击数
        /// </summary>
        public int MonthHits { get; set; }

        /// <summary>
        /// 内容缩略图url地址
        /// </summary>
        [StringLength(200)]
        public string DefaultPicUrl { get; set; }

        /// <summary>
        /// 搜索引擎关键词
        /// </summary>
        [StringLength(100)]
        public string Keyword { get; set; }

        /// <summary>
        /// 搜素引擎描述
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [StringLength(500)]
        public string Info { get; set; }

    }
}
