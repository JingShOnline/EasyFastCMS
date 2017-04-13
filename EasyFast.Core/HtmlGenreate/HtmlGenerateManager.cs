
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Abp.Runtime.Caching;
using Abp.Threading;
using EasyFast.Common;
using EasyFast.Core.Interface;
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
        /// <param name="dict">调用除加参数</param>
        /// <returns></returns>
        public async Task GenerateHtml(string template, string savePath, Dictionary<string, string> dict)
        {
            if (dict != null && dict.ContainsKey("tableName"))
            {
                //生成
                GenerateListHtml(template, savePath, dict);
            }
            else
            {
                //拿到标签数组
                var matches = Regex.Matches(template, EasyFastConsts.TagRegex);
                for (var i = 0; i < matches.Count; i++)
                {
                    var i1 = i;
                    template = template.Replace(matches[i1].Value, ParseTag(matches[i1].Value, dict));

                };
                //保存文件
                var dir = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllText(savePath, template);


            }


        }

        /// <summary>
        /// 生成静态列表文件
        /// </summary>
        /// <param name="template"></param>
        /// <param name="savePath"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        private void GenerateListHtml(string template, string savePath, Dictionary<string, string> dict)
        {
            var tableName = dict["tableName"];
            //总条数 
            var count = AsyncHelper.RunSync(() => _sqlExecuter.SqlQueryAsync<int>(
                $"select count(tleft.Id) from {tableName} tleft join Common_Model as tright on tleft.Id=tright.Id left join [column] as c on c.Id=tright.ColumnId where IsDeleted=0  and c.Id = {dict["columnId"]} "));
            //每页显示条数
            var size = 10;//Convert.ToInt32(dict["size"]);
            //拿到总页数
            int totalPage = Math.Max((int)Math.Ceiling((count * 1.0) / size), 1);
            //生成每一页
            for (int i = 0; i < totalPage; i++)
            {
                savePath = savePath.Replace("{Page}", (i + 1).ToString());
                //拿到标签数组
                var matches = Regex.Matches(template, EasyFastConsts.TagRegex);
                for (var j = 0; j < matches.Count; j++)
                {
                    var j1 = j;
                    template = template.Replace(matches[j1].Value, ParseTag(matches[j1].Value, dict, i, count));
                }


                //保存文件
                var dir = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllText(savePath, template);
            }
        }

        /// <summary>
        /// 解析标签,
        /// </summary>
        /// <param name="tag">标签</param>
        /// <param name="dict">参数</param>
        /// <param name="page">生成列表页时使用 当前页码</param>
        /// <param name="totalCount">生成列表页时必传! 总条数</param>
        /// <returns></returns>
        private string ParseTag(string tag, Dictionary<string, string> dict, int? page = null, int? totalCount = null)
        {
            var trimStart = tag.Trim('$');
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

            if (!sql.Contains("where"))
                sql += " where ";
            if (dto.Parameters != null && dto.Parameters.Count > 0)
                sql = $" {ParseParameters(sql, parameters, dto.Parameters, dto.TagType)}";


            if (dict != null && dict.Count > 0)
                sql = ParseParameters(sql, parameters, dict, dto.TagType);

            //解析ModelType
            var modelStr = Regex.Match(itemTemplate, EasyFastConsts.ModelTypeRegex)
                .Value;
            var modelType = EasyFastStatics.ApplicationAss.GetType(modelStr.Replace("@model ", "")
                    .Replace("List<", "")
                    .Replace(">", "")
                    .Replace("<t", "").Trim());

            //是否是生成列表页
            if (!string.IsNullOrWhiteSpace(dto.TagType) && dto.TagType == "list" && page != null)
            {
                var size = 10;
                int startNum = ((int)page * size) + 1;
                sql = sql.Replace("startNum", startNum.ToString()).Replace("endNum", ((startNum + size) - 1).ToString());
                var srt = modelStr.Replace("@model ", "").Replace("<t>", "").Replace("EasyFast.Application.Dto.TemplateList<", "").Replace(">", "").Trim();
                modelType = EasyFastStatics.ApplicationAss.GetType(srt);
            }

            //排序
            if (!string.IsNullOrWhiteSpace(dto.Sorting))
                sql += $" {dto.Sorting}";

            var model = AsyncHelper.RunSync(() => _sqlExecuter.SqlQuery(modelType, sql, parameters.ToArray()));

            itemTemplate = itemTemplate.Replace(modelStr.Replace("<t>", ""), "");
            itemTemplate = Regex.Replace(itemTemplate, EasyFastConsts.SqlRegex, "");
            //parseHtml  
            return page != null && !string.IsNullOrWhiteSpace(dto.TagType) && dto.TagType == "list" ? RazorHelper.Parsecshtml(itemTemplate, lastModifyTime, new { List = model, Page = page, TotalCount = totalCount }) : RazorHelper.Parsecshtml(itemTemplate, lastModifyTime, model);

        }


        private string ParseParameters(string sql, List<SqlParameter> parameters, Dictionary<string, string> dict, string tagType)
        {
            var sqlParameters = new StringBuilder();
            foreach (var parameter in dict)
            {
                if (parameter.Key.Equals("tableName") || parameter.Key.Equals("columnId"))
                    continue;

                if (parameter.Key.Contains("@"))
                {
                    parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(tagType) && tagType.Equals("content") && parameter.Key.Equals("id"))
                    continue;


                // 取出value
                var pavalue = Regex.Match(parameter.Value, EasyFastConsts.SqlParameterRegex).Value.Trim('\'');
                // and Name = "小明"  --  and Name = @Name
                var replaceParam = Regex.Replace(parameter.Value, EasyFastConsts.SqlParameterRegex, $"@{parameter.Key}");
                // and Name = @Name
                sqlParameters.Append($"{replaceParam}");
                //加入到参数化查询中
                parameters.Add(new SqlParameter($"@{parameter.Key}", pavalue));


            }
            return sql += $" {sqlParameters}";
        }

    }
}
