using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 栏目的基类
    /// </summary>
    public class ColumnDtoBase : EntityDto
    {


        public int orderId;

        /// <summary>
        /// 父栏目Id
        /// </summary>
        public virtual int? ParentId
        {
            get; set;
        }


        /// <summary>
        /// 栏目类型
        /// </summary>
        public virtual ColumnTypeEnum ColumnTypeEnum { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [Required(ErrorMessage = "请填写栏目名称")]
        [StringLength(50)]
        public virtual string Name { get; set; }


        /// <summary>
        /// 栏目标识
        /// </summary>
        public virtual string ColumnIdentify { get; set; }

        /// <summary>
        /// 是否生成静态Html
        /// </summary>
        public virtual bool IsStaticHtml { get; set; }


        /// <summary>
        /// 栏目生成目录
        /// </summary>
        [Required(ErrorMessage = "请填写栏目生成目录")]
        public virtual string Dir { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        public virtual int OrderId { get { if (orderId == 0) { return 99; } else { return orderId; }; } set { orderId = value; } }

        /// <summary>
        /// 栏目图片地址
        /// </summary>
        [StringLength(200)]
        public virtual string ImageUrl { get; set; }

        /// <summary>
        /// 栏目提示信息
        /// </summary>
        [StringLength(500)]
        public virtual string Tooltip { get; set; }

        /// <summary>
        /// 栏目简介
        /// </summary>
        [StringLength(500)]
        public virtual string Info { get; set; }

        /// <summary>
        /// 搜索引擎关键词
        /// </summary>
        [StringLength(50)]
        public virtual string Keywords { get; set; }

        /// <summary>
        /// 搜索引擎描述
        /// </summary>
        [StringLength(200)]
        public virtual string Description { get; set; }
    }
}
