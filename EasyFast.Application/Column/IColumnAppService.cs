using Abp.Application.Services;
using EasyFast.Application.Column.Dto;
using EasyFast.Application.Common.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Specifications;

namespace EasyFast.Application.Column
{
    /// <summary>
    /// 栏目资源
    /// </summary>
    public interface IColumnAppService : IApplicationService
    {

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="search">搜索条件及分页设定</param>
        /// <returns></returns>
        Task<EasyUIGridOutput<TreeGridOutput>> GetTreeGrid(TreeGridInput search);



        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// 获取全站栏目
        /// </summary>
        /// <returns></returns>
        Task<List<SiteColumnModel>> GetSiteColumns();

        /// <summary>
        /// 获取树形结构的栏目名称
        /// </summary>
        /// <returns></returns>
        Task<List<ColumnNameOutput>> GetTreeColumnNameAsync();

        /// <summary>
        /// 获取栏目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> GetColumnAsync<T>(int id);


        /// <summary>
        /// 添加或删除单页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddOrUpdateSingleAsync(SingleColumnDto model);


        /// <summary>
        /// 添加或删除栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddOrUpdateColumn(ColumnDto model);

        /// <summary>
        /// 获取EasyTree格式的菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        Task<List<ColumnTreeMenuOutput>> GetColumnEasyTree(bool isIndexHtml, bool isModel, bool isContentHtml, bool isListHtml);


        /// <summary>
        /// 获取栏目用于生成静态化文件
        /// </summary>
        /// <param name="spec">规约</param>
        /// <returns></returns>
        Task<List<T>> GetGenerateColumn<T>(ISpecification<Core.Entities.Column> spec);


    }
}
