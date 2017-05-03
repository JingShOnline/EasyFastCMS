using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Core.DomainDto
{
    [AutoMapFrom(typeof(Column))]
    public class CleanStaticFileOutput
    {
        public int Id { get; set; }

        /// <summary>
        /// Html生成目录
        /// </summary>
        public string HTMLDir { get; set; }


        /// <summary>
        /// 首页生成规则
        /// </summary>
        public string IndexHtmlRule { get; set; }

        /// <summary>
        /// 列表页生成规则
        /// </summary>
        public string ListHtmlRule { get; set; }

        /// <summary>
        /// 内容页生成规则 
        /// </summary>
        public string ContentHtmlRule { get; set; }

        /// <summary>
        /// 内容表名
        /// </summary>
        public string ModelTableName { get; set; }

    }
}
