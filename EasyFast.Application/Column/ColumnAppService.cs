using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFast.Application.Column.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using EasyFast.Application.Common.Dto;
using System.Linq.Dynamic;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.UI;
using System.Web.Http;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Specifications;
using EasyFast.Application.Config;
using EasyFast.Application.Config.Dto;
using EasyFast.Core;
using LinqKit;
using System;

namespace EasyFast.Application.Column
{
    public class ColumnAppService : EasyFastAppServiceBase, IColumnAppService
    {

        private readonly ICacheManager _cacheManager;

        private readonly ISiteConfigAppService _siteConfigAppService;


        #region 依赖注入
        private readonly IRepository<Core.Entities.Column> _columnRepository;
        public ColumnAppService(IRepository<Core.Entities.Column> columnRepository, ISiteConfigAppService siteConfigAppService, ICacheManager cacheManager)
        {
            _columnRepository = columnRepository;
            _siteConfigAppService = siteConfigAppService;
            _cacheManager = cacheManager;
        }

        #endregion

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
        /// <param name="prefix"></param>
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
        /// 添加或修改单页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddOrUpdateSingleAsync(SingleColumnDto model)
        {
            //拿到网站配置
            var siteOption =
                await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());
            if (string.IsNullOrWhiteSpace(model.IndexHtmlRule))
                model.IndexHtmlRule = $"{model.Dir}index.html";

            if (model.IsIndexHtml && !string.IsNullOrWhiteSpace(siteOption.HTMLDir) && !model.IndexHtmlRule.Contains(siteOption.HTMLDir))
                model.IndexHtmlRule = siteOption.HTMLDir + model.IndexHtmlRule;
            await _columnRepository.InsertOrUpdateAsync(model.MapTo<Core.Entities.Column>());
        }

        /// <summary>
        /// 添加或修改栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddOrUpdateColumn(ColumnDto model)
        {
            //拿到网站配置
            var siteOption =
                await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());

            if (string.IsNullOrWhiteSpace(model.IndexHtmlRule))
                model.IndexHtmlRule = "#";
            else if (!model.IndexHtmlRule.Contains("#") && model.IndexHtmlRule.Contains("html"))
            {
                if (!string.IsNullOrWhiteSpace(siteOption.HTMLDir) && !model.IndexHtmlRule.Contains(siteOption.HTMLDir))
                    model.IndexHtmlRule = siteOption.HTMLDir + model.IndexHtmlRule;
            }

            if (string.IsNullOrWhiteSpace(model.ListHtmlRule))
                model.ListHtmlRule = $@"{model.Dir}List\list_{{Page}}.html";

            if (string.IsNullOrWhiteSpace(model.ContentHtmlRule))
                model.ContentHtmlRule = $@"{model.Dir}Content\{{Year}}\{{Month}}\{{Day}}\{model.Name}_{{Id}}.html";
            else if (!model.ContentHtmlRule.Contains(".html"))
                model.ContentHtmlRule += ".html";

            if (!string.IsNullOrWhiteSpace(siteOption.HTMLDir) && !model.ListHtmlRule.Contains(siteOption.HTMLDir) && model.ListHtmlRule.Contains("html"))
                model.ListHtmlRule = siteOption.HTMLDir + model.ListHtmlRule;

            if (!string.IsNullOrWhiteSpace(siteOption.HTMLDir) && !model.ContentHtmlRule.Contains(siteOption.HTMLDir) && model.ContentHtmlRule.Contains("html"))
                model.ContentHtmlRule = siteOption.HTMLDir + model.ContentHtmlRule;
            await _columnRepository.InsertOrUpdateAsync(model.MapTo<Core.Entities.Column>());

        }


        /// <summary>
        /// 获取EasyTree格式的菜单
        /// </summary>
        /// <param name="isIndexHtml">是否获取仅生成首页的栏目</param>
        /// <param name="isModel">是否获取具有模型的栏目</param>
        /// <param name="isContentHtml"></param>
        /// <param name="isListHtml"></param>
        /// <returns></returns>
        [HttpGet]
        [UnitOfWork(false)]
        public async Task<List<ColumnTreeMenuOutput>> GetColumnEasyTree(bool isIndexHtml, bool isModel, bool isContentHtml, bool isListHtml)
        {
            var conditions = PredicateBuilder.New<Core.Entities.Column>();

            if (isIndexHtml)
                conditions = conditions.Or(o => o.IsIndexHtml);
            if (isListHtml)
                conditions = conditions.Or(o => o.IsListHtml);
            if (isModel)
                conditions = conditions.Or(o => o.ModelId != null);
            if (isContentHtml)
                conditions = conditions.Or(o => o.IsContentHtml);
            var result = await _columnRepository.GetAllListAsync(conditions);

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
                    .Where(o => o.ParentId == null || o.ParentId == 0).Include(o => o.Children);
            var totalCount = await query.CountAsync();
            var list = await query.OrderBy($"{search.Sort} {search.Order}").Skip((search.Page - 1) * search.Rows).Take(search.Rows).ToListAsync();


            return new EasyUIGridOutput<TreeGridOutput> { total = totalCount, rows = list.MapTo<List<TreeGridOutput>>() };
        }

        /// <summary>
        /// 获取栏目用于生成静态化文件
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetGenerateColumn<T>(ISpecification<Core.Entities.Column> spec)
        {
            return await _columnRepository.GetAll().Where(spec.ToExpression()).ProjectTo<T>().ToListAsync();

        }

    }
}
