using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Content.Dto
{
    /// <summary>
    /// 添加内容时所用的Dto 也可用于 编辑 操作
    /// </summary>
    public class AddContentDto : EntityDto
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        public int ColumnId { get; set; }


        /// <summary>
        /// 模型Id
        /// </summary>
        public int ModelId { get; set; }


        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }


        /// <summary>
        /// 简介
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 导读 用于截断内容的一部分,Info为空时代替展示 
        /// </summary>
        public string Guide { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题")]
        public string Title { get; set; }

        /// <summary>
        /// 总点击量
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// 当天点击量
        /// </summary>
        public int DayHits { get; set; }

        /// <summary>
        /// 本周点击量
        /// </summary>
        public int WeekHits { get; set; }

        /// <summary>
        /// 当月点击量
        /// </summary>
        public int MonthHits { get; set; }

        /// <summary>
        /// 默认图片地址
        /// </summary>
        public string DefaultPicUrl { get; set; }

        /// <summary>
        /// 搜素引擎描述
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }
    }
}
