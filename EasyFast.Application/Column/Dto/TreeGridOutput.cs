using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// easyUi输出
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class TreeGridOutput : EntityDto
    {
        /// <summary>
        /// 上级Id
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 栏目类型
        /// </summary>
        public ColumnTypeEnum ColumnTypeEnum { get; set; }
        /// <summary>
        ///数据量
        /// </summary>
        public string ContentCount { get; set; }
        /// <summary>
        /// 排序Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 子栏目
        /// </summary>
        public List<TreeGridOutput> children { get; set; }
    }
}
