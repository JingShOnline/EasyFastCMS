using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.HomeGenerate
{
    /// <summary>
    /// 静态文件生成资源
    /// </summary>
    public interface IHomeGenerateAppService : IApplicationService
    {
        /// <summary>
        /// 生成栏目首页
        /// </summary>
        /// <param name="ids">栏目ids</param>
        /// <returns></returns>
        Task<bool> ColumnIndexGenerate(List<int> ids);
    }
}
