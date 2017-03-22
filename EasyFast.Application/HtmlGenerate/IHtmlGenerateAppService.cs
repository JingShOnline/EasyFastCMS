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
        /// <param name="isAll">生成选项</param>
        /// <returns></returns>
        Task GenerateColumnIndex(List<int> ids, bool isAll = false);

        /// <summary>
        /// 生成网站首页
        /// </summary>
        /// <returns></returns>
        Task GenerateIndex();

        /// <summary>
        /// 生成所有的首页
        /// </summary>
        /// <returns></returns>
        Task GenerateAllIndex();

        /// <summary>
        /// 生成内容
        /// </summary>
        /// <param name="isAll">生成选项</param>
        /// <returns></returns>
        Task GenerateContent(List<int> id);

        /// <summary>
        /// 生成栏目列表页
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isAll">生成选项</param>
        /// <returns></returns>
        Task GenerateColumnList(List<int> ids, bool isAll = false);
    }
}
