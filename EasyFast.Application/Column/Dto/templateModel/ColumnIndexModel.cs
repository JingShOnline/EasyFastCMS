using Abp.Application.Services.Dto;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto.templateModel
{
    /// <summary>
    /// 模板文件栏目首页模型
    /// </summary>
    public class ColumnIndexModel : EntityDto
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
        /// 鼠标放到栏目上的提示
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// 栏目图片
        /// </summary>
        public string ImageUrl { get; set; }

    }
}
