using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EasyFast.Application.Content.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Content
{
    /// <summary>
    /// 内容资源
    /// </summary>
    public interface IContentAppService : IApplicationService
    {
        /// <summary>
        /// 分页并搜索获取内容信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GridContentOutput>> GetGridContents(PagedGridContentInput input);
    }
}
