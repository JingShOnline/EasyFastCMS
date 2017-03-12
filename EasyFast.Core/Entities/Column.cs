using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Core.Entities
{
    public class Column : Entity
    {
        /// <summary>
        /// 栏目类别
        /// </summary>
        public ColumnTypeEnum ColumnTypeEnum { get; set; }


        public int? ParentId { get; set; }
        public ICollection<Column> Children { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        /// <summary>
        /// 栏目目录
        /// </summary>
        [Required]
        public string Dir { get; set; }

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

        /// <summary>
        /// 栏目首页模板
        /// </summary>
        [StringLength(100)]
        public string IndexTemplate { get; set; }

        /// <summary>
        /// 栏目列表页模板
        /// </summary>
        [StringLength(100)]
        public string ListTemplate { get; set; }

        /// <summary>
        /// 栏目内容页模板
        /// </summary>
        [StringLength(100)]
        public string ContentTemplate { get; set; }

        /// <summary>
        /// 是否生成首页
        /// </summary>
        public bool IsIndexHtml { get; set; }

        /// <summary>
        /// 首页生成规则
        /// </summary>
        [StringLength(100)]
        public string IndexHtmlRule { get; set; }

        /// <summary>
        /// 是否生成列表页
        /// </summary>
        public bool IsListHtml { get; set; }

        /// <summary>
        /// 列表页生成规则
        /// </summary>
        [StringLength(100)]
        public string ListHtmlRule { get; set; }

        /// <summary>
        /// 是否生成内容页
        /// </summary>
        public bool IsContentHtml { get; set; }

        /// <summary>
        /// 内容页生成规则
        /// </summary>
        [StringLength(100)]
        public string ContentHtmlRule { get; set; }

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
        [StringLength(100)]
        public string SingleHtmlRule { get; set; }

        public int OrderId { get; set; }

    }
}
