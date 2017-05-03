using System.Collections.Generic;
using Abp.Domain.Services;
using EasyFast.Core.DomainDto;

namespace EasyFast.Core.HtmlGenreate
{
    /// <summary>
    /// 生成静态文件领域服务
    /// </summary>
    public interface IHtmlGenerateManager : IDomainService
    {
        /// <summary>
        /// 通用的生成静态文件服务
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="savePath">保存路径 Article_id_index.html</param>
        /// <param name="dict">方法调用附加参数</param>
        /// <returns></returns>
        void GenerateHtml(string template, string savePath, Dictionary<string, string> dict);

        /// <summary>
        /// 清理无用静态文件领域服务
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        void CleanStaticFile(CleanStaticFileOutput dto);
    }
}
