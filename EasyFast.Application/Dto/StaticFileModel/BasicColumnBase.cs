using System.Collections.Generic;
using Abp.Application.Services.Dto;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Dto.StaticFileModel
{
    /// <summary>
    /// 基本的具有子栏目的栏目Dto
    /// </summary>
    public class BasicColumnBase : EntityDto
    {
        /// <summary>
        /// 栏目类型
        /// </summary>
        public ColumnTypeEnum ColumnTypeEnum { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 子栏目
        /// </summary>
        public virtual List<BasicColumnBase> Children { get; set; }
    }
}
