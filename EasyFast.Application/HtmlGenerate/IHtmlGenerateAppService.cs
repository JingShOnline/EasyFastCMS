using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;

namespace EasyFast.Application.HtmlGenerate
{
    /// <summary>
    /// 静态文件生成资源
    /// </summary>
    public interface IHtmlGenerateAppService : IApplicationService
    {
        /// <summary>
        /// 生成栏目首页
        /// </summary>
        /// <param name="ids">栏目ids</param>
        /// <returns></returns>
        Task ColumnIndexGenerate(List<int> ids);
    }
}
