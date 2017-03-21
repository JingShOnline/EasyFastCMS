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
using EasyFast.Common.FileRule;

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


        public HtmlGenerateAppService(IColumnAppService columnAppService, ICacheManager cacheManager, IHtmlGenerateManager htmlGenerateManager)
        {
            _columnAppService = columnAppService;
            _cacheManager = cacheManager;
            _htmlGenerateManager = htmlGenerateManager;
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
            for (int i = 0; i < list.Count; i++)
            {
                var i1 = i;
               
                //拿到栏目的模板文件 以文件的最后修改时间做缓存
                string fileName = list[i].IndexTemplate.Substring(list[i].IndexTemplate.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"{fileName}{File.GetLastWriteTime(list[i].IndexTemplate)}",
                    () => File.ReadAllText(list[i1].IndexTemplate, Encoding.UTF8));


                //生成规则 暂时仅支持{Id} {Name} {Year} {Month} {Day} [Title]
                var rulePath = RuleParseHelper.Parse(new StringBuilder(list[i1].IndexHtmlRule), list[i1].Id.ToString(), list[i1].Name);

                taskArray[i] = _htmlGenerateManager.GenerateHtml<ColumnIndexModel>(template, list[i1].Dir + rulePath);
            }
            //等待所有的task执行完成
            await Task.WhenAll(taskArray);

        }
    }
}
