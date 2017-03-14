using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 用于栏目表格显示Dto 仅有基本属性
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class ColumnGridOutput : EntityDto
    {
        /// <summary>
        /// 父栏目Id
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 栏目类型String
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 数据量
        /// </summary>
        public string ContentCount { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 子栏目集合
        /// </summary>
        public List<ColumnGridOutput> Children { get; set; }
    }
}
