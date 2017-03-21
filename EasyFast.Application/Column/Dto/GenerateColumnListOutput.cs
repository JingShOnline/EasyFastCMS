using Abp.AutoMapper;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 生成静态化文件所用栏目列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class GenerateColumnListOutput : GenerateColumnBase
    {

        /// <summary>
        /// 列表生成模板
        /// </summary>
        public string ListTemplate { get; set; }

        /// <summary>
        /// 列表生成规则
        /// </summary>
        public string ListHtmlRule { get; set; }
    }
}
