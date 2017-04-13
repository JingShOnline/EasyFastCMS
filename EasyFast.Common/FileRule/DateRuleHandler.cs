using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Common.FileRule
{
    /// <summary>
    /// 日期部分解析
    /// </summary>
    public class DateRuleHandler : IRuleHandler
    {
        public StringBuilder Handler(StringBuilder sb, DateTime? date, string id, string name)
        {
            var now = date ?? DateTime.Now;

            return sb.Replace("{Year}", now.Year.ToString())
                 .Replace("{Month}", now.Month.ToString())
                 .Replace("{Day}", now.Day.ToString());
        }
    }
}
