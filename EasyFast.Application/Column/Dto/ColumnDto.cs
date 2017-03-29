using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 栏目Dto
    /// </summary>
    [AutoMap(typeof(Core.Entities.Column))]
    [AutoMapTo(typeof(SingleColumnDto))]
    public sealed class ColumnDto : ColumnDtoBase
    {

        /// <summary>
        /// 
        /// </summary>
        public ColumnDto() : base()
        {
            ColumnTypeEnum = Core.Entities.ColumnTypeEnum.Normal;

        }

        #region 模板及生成选项
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
        #endregion
    }
}
