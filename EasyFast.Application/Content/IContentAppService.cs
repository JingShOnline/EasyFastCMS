using Abp.Application.Services;
using EasyFast.Application.Content.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Web.Models;
using EasyFast.Application.Common.Dto;

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
        [DontWrapResult]
        Task<EasyUIGridOutput<GridContentOutput>> GetGridContents(DataGridInput input);

        /// <summary>
        /// 删除内容
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteContent(int[] ids);


        /// <summary>
        /// 根据id获取内容用于编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AddContentDto> GetContent(int id);

        /// <summary>
        /// 根据栏目id获取生成所用的内容
        /// </summary>
        /// <returns></returns>
        Task<List<GenerateContentOutput>> GetGenerateContentsByCIds(List<int> ids);
    }
}

