using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFast.Common.FileRule
{
    /// <summary>
    /// 文件规则解析帮助类
    /// </summary>
    public class RuleParseHelper
    {
        private static List<IRuleHandler> _list;
        static RuleParseHelper()
        {
            _list = new List<IRuleHandler> { new BasicRuleHandler(), new DateRuleHandler() };
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Parse(StringBuilder sb, string id, string name, DateTime? data)
        {
            foreach (var ruleHandler in _list)
            {
                ruleHandler.Handler(sb, data, id, name);
            }

            return sb.ToString();
        }
    }
}
