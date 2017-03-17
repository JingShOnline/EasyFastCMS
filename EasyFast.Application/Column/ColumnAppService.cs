using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Column.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using AutoMapper;
using EasyFast.Application.Common.Dto;
using System.Linq.Dynamic;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.UI;
using EasyFast.Application.Dto;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using System.Web;
using System.Web.Http;

namespace EasyFast.Application.Column
{
    public class ColumnAppService : EasyFastAppServiceBase, IColumnAppService
    {
        #region 依赖注入
        private readonly IRepository<Core.Entities.Column> _columnRepository;
        public ColumnAppService(IRepository<Core.Entities.Column> columnRepository)
        {
            _columnRepository = columnRepository;
        }

        public void Add(ColumnDto model)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(Core.Entities.Column model)
        {
            await _columnRepository.InsertAsync(model);
        }


        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var column = await _columnRepository.GetAll().Where(o => o.Id == id).Include(o => o.Children).SingleOrDefaultAsync();
            if (column == null)
                throw new UserFriendlyException("该栏目不存在或已被删除");
            if (column.Children.Count > 0)
                throw new UserFriendlyException("该栏目下还具有子栏目,请删除所有子栏目后再删除此栏目");

            await _columnRepository.DeleteAsync(column);

        }


        /// <summary>
        /// 获取栏目用于表格展示
        /// </summary>
        /// <returns></returns>
        public async Task<PagedResultDto<ColumnGridOutput>> GetColumnGridAsync(PagedSortedAndFilteredInputDto input)
        {
            if (string.IsNullOrEmpty(input.Sorting))
                input.Sorting = "OrderId";
            var query = _columnRepository.GetAll().Where(o => o.ParentId == null || o.ParentId == 0).Where(o => o.ColumnTypeEnum == ColumnTypeEnum.Normal).Include(o => o.Children).WhereIf(!string.IsNullOrEmpty(input.Filter), o => o.Name.Contains(input.Filter));
            var count = await query.CountAsync();
            var list = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            return new PagedResultDto<ColumnGridOutput>(count, list.MapTo<List<ColumnGridOutput>>());
        }


        /// <summary>
        /// 修改栏目 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Core.Entities.Column model)
        {
            var column = await _columnRepository.GetAsync(model.Id);
            model.MapTo(column);
            await _columnRepository.UpdateAsync(column);
        }


        /// <summary>
        /// 获取树形结构的栏目名称
        /// </summary>
        /// <returns></returns>
        public async Task<List<ColumnNameOutput>> GetTreeColumnNameAsync()
        {
            var query = await _columnRepository.GetAll().Where(o => o.ParentId == null || o.ParentId == 0).Where(o => o.ColumnTypeEnum == ColumnTypeEnum.Normal).Include(o => o.Children).OrderBy(o => o.OrderId).ToListAsync();

            var list = query.MapTo<List<ColumnNameOutput>>();

            foreach (var temp in list)
            {
                TreeColumnNameSorting(temp.Children, "...├-");
            }

            return list;
        }

        /// <summary>
        /// 对栏目名称进行顺序处理
        /// </summary>
        /// <param name="list"></param>
        private void TreeColumnNameSorting(List<ColumnNameOutput> list, string prefix)
        {
            foreach (var temp in list)
            {
                temp.Name = $"{prefix}{temp.Name}";
                TreeColumnNameSorting(temp.Children, $"...{prefix}");
            }
        }

        /// <summary>
        /// 获取栏目 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetColumnAsync<T>(int id)
        {
            var column = await _columnRepository.GetAll().Where(o => o.Id == id).SingleOrDefaultAsync();

            return column.MapTo<T>();
        }

        /// <summary>
        /// 添加或删除单页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddOrUpdateSingleAsync(SingleColumnDto model)
        {
            var column = model.MapTo<Core.Entities.Column>();
            // _columnManger.InitSignleColumn(column);
            if (model.Id == 0)
            {
                await AddAsync(column);
            }
            else
            {
                await UpdateAsync(column);
            }
        }

        /// <summary>
        /// 添加或删除栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddOrUpdateColumn(ColumnDto model)
        {
            var column = model.MapTo<Core.Entities.Column>();
            //_columnManger.InitColumn(column);
            if (model.Id == 0)
            {
                await AddAsync(column);
            }
            else
                await UpdateAsync(column);
        }


        /// <summary>
        /// 获取EasyTree格式的菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ColumnTreeMenuOutput>> GetColumnEasyTree(bool? isIndexHtml)
        {
            var query = _columnRepository.GetAll().Where(o => o.ParentId == null || o.ParentId == 0).WhereIf(isIndexHtml.HasValue, o => o.IsIndexHtml).Include(o => o.Children);
            var result = await query.ToListAsync();
            var list = result.MapTo<List<ColumnTreeMenuOutput>>();
            ToEasyUiTree(list);
            return list;
        }


        private void ToEasyUiTree(List<ColumnTreeMenuOutput> list)
        {
            foreach (var temp in list)
            {
                temp.Attributes = new { ModelId = temp.ModelId, Controller = temp.ModelManagerControlerPath, ModelName = temp.ModelModelName };
                ToEasyUiTree(temp.Children);
            }
        }

        /// <summary>
        /// 分页获取栏目用于表格展示
        /// </summary>
        /// <returns></returns>
        public async Task<EasyUIGridOutput<TreeGridOutput>> GetTreeGrid(TreeGridInput search)
        {
            var query =
                _columnRepository.GetAll()
                    .Where(o => o.ParentId == null || o.ParentId == 0)
                    .Where(o => o.ColumnTypeEnum == ColumnTypeEnum.Normal).Include(o => o.Children);
            var totalCount = await query.CountAsync();
            var list = await query.OrderBy($"{search.Sort} {search.Order}").Skip((search.Page - 1) * search.Rows).Take(search.Rows).ToListAsync();


            return new EasyUIGridOutput<TreeGridOutput> { total = totalCount, rows = list.MapTo<List<TreeGridOutput>>() };
        }
    }
}
