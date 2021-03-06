﻿using Abp.Application.Services;
using Abp.Runtime.Caching;
using Abp.UI;
using EasyFast.Application.Column;
using EasyFast.Application.Column.Dto;
using EasyFast.Application.Config;
using EasyFast.Application.Config.Dto;
using EasyFast.Common.FileRule;
using EasyFast.Core;
using EasyFast.Core.HtmlGenreate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using EasyFast.Application.Column.Specification;
using EasyFast.Application.Content;
using EasyFast.Core.DomainDto;

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

        private readonly IContentAppService _contentAppService;


        public HtmlGenerateAppService(IColumnAppService columnAppService, ICacheManager cacheManager, IHtmlGenerateManager htmlGenerateManager, ISiteConfigAppService siteConfigAppService, IContentAppService contentAppService)
        {
            _columnAppService = columnAppService;
            _cacheManager = cacheManager;
            _htmlGenerateManager = htmlGenerateManager;
            _siteConfigAppService = siteConfigAppService;
            _contentAppService = contentAppService;
        }

        /// <summary>
        /// 根据选中的栏目id生成栏目首页 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isAll">生成选项</param>
        /// <returns></returns>
        public async Task GenerateColumnIndex(List<int> ids, bool isAll)
        {
            if (!isAll)
                if (ids.Count <= 0)
                    throw new UserFriendlyException("请选择要生成的栏目或者点击全部生成");
            //拿到待生成的栏目集合
            var list = await _columnAppService.GetGenerateColumn<GenerateColumnIndexOutput>(new GenerateIndexSpecification(isAll, ids));
            var taskArray = new Task[list.Count];
            //拿到网站配置
            var siteOption =
              await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());
            for (var i = 0; i < list.Count; i++)
            {
                var fileName = list[i].IndexTemplate.Substring(list[i].IndexTemplate.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                var fullPath = $"{EasyFastConsts.BaseDirectory}{siteOption.TemplateDir}{list[i].IndexTemplate}";
                if (!File.Exists(fullPath))
                    throw new UserFriendlyException($"请在{siteOption.TemplateDir}目录下查看是否存在{fileName}模板文件");
                var i1 = i;
                //拿到栏目的模板文件 以文件的最后修改时间做缓存
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"{fullPath}{File.GetLastWriteTime(fullPath)}",
                    () => File.ReadAllText(fullPath, Encoding.UTF8));

                //生成规则 暂时仅支持{Id} {Name} {Year} {Month} {Day} [Title]
                var rulePath = RuleParseHelper.Parse(new StringBuilder(list[i1].IndexHtmlRule), list[i1].Id.ToString(), list[i1].Name, null);
                //地址 CurrentPath +  HtmlDir + Column Dir + rulePath  例 MapPath(~)\Index_1.html
                taskArray[i] = Task.Factory.StartNew(() => _htmlGenerateManager.GenerateHtml(template, EasyFastConsts.BaseDirectory + rulePath.Trim(), null));


            }
            //等待所有的task执行完成
            await Task.WhenAll(taskArray);
            Debug.WriteLine("执行成功!");
        }

        /// <summary>
        /// 网站首页生成
        /// </summary>
        /// <returns></returns>
        public  Task GenerateIndex()
        {
            return null;
        }

        /// <summary>
        /// 网站所有首页生成
        /// </summary>
        /// <returns></returns>
        public async Task GenerateAllIndex()
        {
            //生成首页
            await GenerateIndex();
            //生成栏目页面
            await GenerateColumnIndex(null, true);
        }

        /// <summary>
        /// 生成内容页
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [UnitOfWork(false)]
        public async Task GenerateContent(List<int> ids)
        {

            if (ids.Count <= 0)
                throw new UserFriendlyException("请选择要生成内容页的栏目");
            var contents = await _contentAppService.GetGenerateContentsByCIds(ids);
            if (contents.Count <= 0)
                throw new UserFriendlyException("您选择的栏目下暂时没有要生成的内容页");

            //拿到网站配置
            var siteOption =
              await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                    .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());
            for (var i = 0; i < contents.Count; i++)
            {
                var fileName = contents[i].ColumnContentTemplate.Substring(contents[i].ColumnContentTemplate.LastIndexOf("\\", StringComparison.Ordinal) + 1);

                var fullPath = $"{EasyFastConsts.BaseDirectory}{siteOption.TemplateDir}{contents[i].ColumnContentTemplate}";

                if (!File.Exists(fullPath))
                    throw new UserFriendlyException($"请在{siteOption.TemplateDir}目录下查看是否存在{fileName}模板文件");

                var i1 = i;

                //拿到栏目的模板文件 以文件的最后修改时间做缓存
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"{fullPath}{File.GetLastWriteTime(fullPath)}",
                    () => File.ReadAllText(fullPath, Encoding.UTF8));

                //生成规则 暂时仅支持{Id} {Name} {Year} {Month} {Day} [Title]
                var rulePath = RuleParseHelper.Parse(new StringBuilder(contents[i1].ColumnContentHtmlRule), contents[i1].Id.ToString(), contents[i1].Title, contents[i1].LastModificationTime);

                //地址 CurrentPath +  HtmlDir + Column Dir + rulePath  例 MapPath(~)\Column\Index_1.html
                var dict = new Dictionary<string, string> { { "id", $"and tleft.id = '{contents[i1].Id}'" } };

                _htmlGenerateManager.GenerateHtml(template, EasyFastConsts.BaseDirectory + rulePath.Trim(), dict);

            }

        }

        /// <summary>
        /// 生成栏目列表页
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public async Task GenerateColumnList(List<int> ids, bool isAll = false)
        {
            if (!isAll)
                if (ids.Count <= 0)
                    throw new UserFriendlyException("请选择要生成的栏目或者点击全部生成");
            var columns = await _columnAppService.GetGenerateColumn<GenerateColumnListOutput>(new GenerateListSpecification(isAll, ids));
            if (columns.Count <= 0)
                throw new UserFriendlyException("暂时没有需要生成的栏目");
            var siteOption = await _cacheManager.GetCache<string, SiteOptionDto>(EasyFastConsts.TemplateCacheKey)
                .GetAsync("siteOptionCache", () => _siteConfigAppService.GetSiteOption());
            var taskArray = new Task[columns.Count];
            for (var i = 0; i < columns.Count; i++)
            {
                var i1 = i;
                string fileName = columns[i].ListTemplate.Substring(columns[i1].ListTemplate.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                var fullPath = $"{EasyFastConsts.BaseDirectory}{siteOption.TemplateDir}{columns[i].ListTemplate}";
                if (!File.Exists(fullPath))
                    throw new UserFriendlyException($"请在{siteOption.TemplateDir}目录下查看是否存在{fileName}模板文件");

                //拿到栏目的模板文件 以文件的最后修改时间做缓存
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"{fullPath}{File.GetLastWriteTime(fullPath)}",
                    () => File.ReadAllText(fullPath, Encoding.UTF8));
                var rulePath = RuleParseHelper.Parse(new StringBuilder(columns[i1].ListHtmlRule), columns[i1].Id.ToString(), columns[i1].Name, null);

                taskArray[i] = Task.Factory.StartNew(() => _htmlGenerateManager.GenerateHtml(template, EasyFastConsts.BaseDirectory + rulePath.Trim(), null));
            }
            await Task.WhenAll(taskArray);
        }


        public async Task CleanStaticFile(List<int> ids)
        {
            //拿到栏目
            var list = await _columnAppService.GetGenerateColumn<CleanStaticFileOutput>(new CleanStaticFileSpecification(ids));
            var taskArray = new Task[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                var i1 = i;
                taskArray[i1] = Task.Factory.StartNew(() => _htmlGenerateManager.CleanStaticFile(list[i1]));
            }
            await Task.WhenAll(taskArray);
        }
    }
}
