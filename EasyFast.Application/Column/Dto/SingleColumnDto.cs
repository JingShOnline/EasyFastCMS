using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto
{
    [AutoMap(typeof(Core.Entities.Column))]
    public class SingleColumnDto : EntityDto
    {
        /// <summary>
        /// 父栏目
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 栏目生成目录
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 是否生成单页节点
        /// </summary>
        public bool IsCreateSingle { get; set; }

        /// <summary>
        /// 单页节点模板
        /// </summary>
        [StringLength(100)]
        public string SingleTemplate { get; set; }

        /// <summary>
        /// 单页节点生成规则
        /// </summary>
        public string SingleHtmlRule { get; set; }

        /// <summary>
        /// 栏目图片地址
        /// </summary>
        [StringLength(200)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 栏目提示信息
        /// </summary>
        [StringLength(500)]
        public string Tooltip { get; set; }

        /// <summary>
        /// 栏目简介
        /// </summary>
        [StringLength(500)]
        public string Info { get; set; }

        /// <summary>
        /// 搜索引擎关键词
        /// </summary>
        [StringLength(50)]
        public string Keywords { get; set; }

        /// <summary>
        /// 搜索引擎描述
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }

    }
}
