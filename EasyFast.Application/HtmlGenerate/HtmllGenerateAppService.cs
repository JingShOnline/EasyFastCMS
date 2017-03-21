using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Json;
using Abp.Runtime.Caching;
using Abp.UI;
using EasyFast.Application.Column;
using EasyFast.Application.Column.Dto;
using EasyFast.Application.Column.Dto.templateModel;
using EasyFast.Application.Dto;
using EasyFast.Core;
using EasyFast.Core.HtmlGenreate;
using System.Web.Http;
using Abp.Domain.Uow;
using EasyFast.Application.Config;
using EasyFast.Common.FileRule;
using EasyFast.Application.Config.Dto;

namespace EasyFast.Application.HtmlGenerate
{
    /// <summary>
    /// 静态文件生成资源
    /// </summary>
    public class HtmlGenerateAppService : ApplicationService, IHtmlGenerateAppService
    {
        private readonly IColumnAppService _columnAppService;

        private readonly ICacheManager _cacheManager;

        private readonly IHtmlGenerateManager _htmlGenerateManager;

        private readonly ISiteConfigAppService _siteConfigAppService;
        public HtmlGenerateAppService(IColumnAppService columnAppService, ICacheManager cacheManager, IHtmlGenerateManager htmlGenerateManager, ISiteConfigAppService siteConfigAppService)
        {
            _columnAppService = columnAppService;
            _cacheManager = cacheManager;
            _htmlGenerateManager = htmlGenerateManager;
            _siteConfigAppService = siteConfigAppService;
        }

        /// <summary>
        /// 根据选中的栏目id生成栏目首页 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task ColumnIndexGenerate(List<int> ids)
        {

            if (ids.Count <= 0)
                throw new UserFriendlyException("请选择要生成的栏目或者点击全部生成");
            //拿到待生成的栏目集合
            var list = await _columnAppService.GetGenerateColumnByIds<GenerateColumnIndexOutput>(ids);
            var taskArray = new Task[list.Count];
            //拿到网站配置
            var siteOption =
              await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());
            for (int i = 0; i < list.Count; i++)
            {
                string fileName = list[i].IndexTemplate.Substring(list[i].IndexTemplate.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                if (!File.Exists(list[i].IndexTemplate))
                    throw new UserFriendlyException($"请在{siteOption.TemplateDir}目录下查看是否存在{fileName}模板文件");
                var i1 = i;
                //拿到栏目的模板文件 以文件的最后修改时间做缓存
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"{fileName}{File.GetLastWriteTime(list[i].IndexTemplate)}",
                    () => File.ReadAllText(list[i1].IndexTemplate, Encoding.UTF8));

                //生成规则 暂时仅支持{Id} {Name} {Year} {Month} {Day} [Title]
                var rulePath = RuleParseHelper.Parse(new StringBuilder(list[i1].IndexHtmlRule), list[i1].Id.ToString(), list[i1].Name);
                //地址 CurrentPath +  HtmlDir + Column Dir + rulePath  例 MapPath(~)\Column\Index_1.html
                taskArray[i] = _htmlGenerateManager.GenerateHtml(template, EasyFastConsts.BaseDirectory + siteOption.HTMLDir + list[i1].Dir + rulePath);
            }
            //等待所有的task执行完成
            await Task.WhenAll(taskArray);

        }

        /// <summary>
        /// 网站首页生成
        /// </summary>
        /// <returns></returns>
        public async Task GenerateIndex()
        {
            var siteOption =
                await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());

            var indexPath = siteOption.HTMLDir + "\\Index.html";//  $@"{EasyFastConsts.StaticFile}\Index.html";
            if (!File.Exists(indexPath))
                throw new UserFriendlyException($"请在{siteOption.HTMLDir}目录下查看是否存在Index.html文件");
            //拿到网站首页模板以文件的最后修改时间做缓存
            var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"Index.html{File.GetLastWriteTime(indexPath)}",
               () => File.ReadAllText(indexPath, Encoding.UTF8));
            await _htmlGenerateManager.GenerateHtml(template, indexPath);
        }
    }
}
