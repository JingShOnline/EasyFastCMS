
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
using Abp.Threading;
using EasyFast.Common;
using Newtonsoft.Json;

namespace EasyFast.Core.HtmlGenreate
{
    public class HtmlGenerateManager : DomainService, IHtmlGenerateManager
    {

        private readonly ICacheManager _cacheManager;

        private readonly ISqlExecuter _sqlExecuter;

        public HtmlGenerateManager(ICacheManager cacheManager, ISqlExecuter sqlExecuter)
        {
            _cacheManager = cacheManager;
            _sqlExecuter = sqlExecuter;
        }

        /// <summary>
        /// 通用的静态文件生成方法
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        public async Task GenerateHtml<T>(string template, string savePath)
        {
            //拿到标签数组
            var matches = Regex.Matches(template, EasyFastConsts.TagRegex);
            for (var i = 0; i < matches.Count; i++)
            {
                var i1 = i;

                var trimStart = matches[i1].Value.TrimStart('$');
                var dto = JsonConvert.DeserializeObject<ParseTag>(trimStart);
                //根据action与type拿到对应的模板
                var tagPath = $@"{EasyFastConsts.TagPath}\{dto.Type}\{dto.Action}{EasyFastConsts.TemplateType}";
                //Cache TemplateCache -  拿文件的名称和最后修改时间做缓存名
                var lastModifyTime = $"{dto.Action}{File.GetLastWriteTime(tagPath)}";
                var itemTemplate = _cacheManager.GetCache<string, string>(EasyFastConsts.TemplateCacheKey)
                       .Get(lastModifyTime,
                            () =>
                               File.ReadAllText(tagPath));

                //取出sql
                var sql = Regex.Match(itemTemplate, EasyFastConsts.SqlRegex).Groups[1].Value;
                //拼接sql
                var parameters = new List<SqlParameter>();
                if (dto.Parameters != null && dto.Parameters.Count > 0)
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
                    sql += $" where {sqlParameters}";
                }
                //排序
                if (!string.IsNullOrWhiteSpace(dto.Sorting))
                    sql += $" {dto.Sorting}";


                var model = AsyncHelper.RunSync(() => _sqlExecuter.SqlQuery<T>(sql, parameters.ToArray()));

                //parseHtml
                var resulthtml = RazorHelper.ParseCshtml<T>(itemTemplate, lastModifyTime, model);

                //替换
                var replacestr = Regex.Replace(resulthtml, EasyFastConsts.SqlRegex, "");

                template = Regex.Replace(template, $"\\{matches[i1].Value}", replacestr);


            }
            if (matches.Count > 0)
            {
                //保存文件
                var dir = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(dir))
                    if (dir != null) Directory.CreateDirectory(dir);
                File.WriteAllText(savePath, template);
            }

        }

    }
}
