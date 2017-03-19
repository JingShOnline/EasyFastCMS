using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Json;
using Abp.Runtime.Caching;
using Abp.UI;
using EasyFast.Application.Column;
using EasyFast.Application.Column.Dto;
using EasyFast.Application.Dto;
using EasyFast.Core;

namespace EasyFast.Application.HtmlGenerate
{
    /// <summary>
    /// 静态文件生成资源
    /// </summary>
    public class HtrmlGenerateAppService : ApplicationService, IHtmlGenerateAppService
    {
        private readonly IColumnAppService _columnAppService;

        private readonly ICacheManager _cacheManager;


        public HtrmlGenerateAppService(IColumnAppService columnAppService, ICacheManager cacheManager)
        {
            _columnAppService = columnAppService;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// 根据选中的栏目id生成栏目首页 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> ColumnIndexGenerate(List<int> ids)
        {
            if (ids.Count <= 0)
                throw new UserFriendlyException("请选择要生成的栏目或者点击全部生成");
            //拿到待生成的栏目集合
            var list = await _columnAppService.GetGenerateColumnByIds<GenerateColumnIndexOutput>(ids);

            foreach (var temp in list)
            {
                var template = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey).Get($"ColumnIndexCache_{temp.Id}{temp.IndexTemplate}", () => File.ReadAllText(temp.IndexTemplate));
                //拿到标签数组
                var matches = Regex.Matches(EasyFastConsts.TagRegex, template);
                foreach (Match m in matches)
                {

                    var dto = JsonSerializationHelper.DeserializeWithType<TagDto>(m.Value.TrimStart('$'));
                    //根据action与type拿到对应的模板
                    var itemTemplate = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey)
                        .Get($"{dto.Type}_{dto.Action}",
                            () =>
                                File.ReadAllText(
                                    $"{EasyFastConsts.TagPath}/{dto.Type}{dto.Action}{EasyFastConsts.TemplateType}"));

                    //取出sql
                    var sql = Regex.Match(itemTemplate, EasyFastConsts.SqlRegex).Groups[1].Value;
                    //拼接sql
                    var parameters = new List<SqlParameter>();
                    if (dto.Parameters.Count > 0)
                    {
                        var sqlParameters = new StringBuilder();
                        foreach (var parameter in dto.Parameters)
                        {
                            // 取出value
                            var pavalue = Regex.Match(parameter.Value, EasyFastConsts.SqlParameterRegex).Value.Trim('"');
                            // and Name = "小明"  --  and Name = @Name
                            var replaceParam = Regex.Replace(parameter.Value, EasyFastConsts.SqlParameterRegex, $"@{parameter.Key}");
                            // and Name = @Name
                            sqlParameters.Append($"{parameter.Key} = {replaceParam}");
                            //加入到参数化查询中
                            parameters.Add(new SqlParameter($"@{parameter.Key}", pavalue));

                        }
                        sql += $" where {sqlParameters.ToString()}";

                    }
                    //排序
                    if (string.IsNullOrWhiteSpace(dto.Sorting))
                        sql += $" {dto.Sorting}";
                    //进行查询
                    var modelType = Type.GetType($"{EasyFastConsts.StaticFileModelAssembly}.BasicColumnBase");

                    
                }
            }

            return true;

        }
    }


}
