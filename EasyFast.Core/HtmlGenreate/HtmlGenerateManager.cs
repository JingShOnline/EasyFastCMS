
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Abp.Json;
using Abp.Runtime.Caching;

namespace EasyFast.Core.HtmlGenreate
{
    public class HtmlGenerateManager : DomainService, IHtmlGenerateManager
    {

        private readonly ICacheManager _cacheManager;

        private ISqlExecuter _sqlExecuter;

        public HtmlGenerateManager(ICacheManager cacheManager, ISqlExecuter sqlExecuter)
        {
            _cacheManager = cacheManager;
            _sqlExecuter = sqlExecuter;
        }

        /// <summary>
        /// 通用的Dto生成方法
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="modelName">模型名称</param>
        /// <returns></returns>
        public async Task GenerateHtml(string template, string modelName)
        {
            //拿到标签数组
            var matches = Regex.Matches(EasyFastConsts.TagRegex, template);
            foreach (Match m in matches)
            {

                var dto = JsonSerializationHelper.DeserializeWithType<ParseTag>(m.Value.TrimStart('$'));
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
                var modelType = Type.GetType($"{EasyFastConsts.StaticFileModelAssembly}.{modelName}");

                var model = await _sqlExecuter.SqlQuery(modelType, sql, parameters.ToArray());

                //parseHtml

            }
        }
    }
}
