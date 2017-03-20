using Abp.Application.Services;
using EasyFast.Application.Column;
using EasyFast.Application.Htmlenerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.HtmlGenerate
{
    /// <summary>
    /// 生成静态文件资源 
    /// </summary>
    public class HtmlGenerateAppService : ApplicationService, IHtmlGenerateAppService
    {

        private readonly IColumnAppService _columnAppService;

        public HtmlGenerateAppService(IColumnAppService columnAppService)
        {
            _columnAppService = columnAppService;
        }

        /// <summary>
        /// 根据所选栏目生成静态文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<bool> ColumnIndexGenerate(List<int> ids)
        {
            _columnAppService
        }
    }
}
