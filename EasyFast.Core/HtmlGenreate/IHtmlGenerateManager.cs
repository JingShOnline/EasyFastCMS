using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

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
        /// <returns></returns>
        Task GenerateHtml<T>(string template, string savePath);
    }
}
