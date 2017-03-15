using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EasyFast.Application.Column.Dto;
using EasyFast.Application.Common.Dto;
using EasyFast.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column
{
    /// <summary>
    /// 栏目资源
    /// </summary>
    public interface IColumnAppService : IApplicationService
    {
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="model"></param>
        Task AddAsync(Core.Entities.Column model);

        /// <summary>
        /// 分页获取栏目用于表格展示
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<ColumnGridOutput>> GetColumnGridAsync(PagedSortedAndFilteredInputDto input);



        /// <summary>
        /// 修改栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync(Core.Entities.Column model);


        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);


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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<EasyUITree>> GetColumnEasyTree();
    }
}
