using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Common.FileRule
{
    /// <summary>
    /// 基本的规则解析
    /// </summary>
    public class BasicRuleHandler : IRuleHandler
    {
        public StringBuilder Handler(StringBuilder sb, string id, string name)
        {
            return sb.Replace("{Id}", id).Replace("{Name}", name).Replace("{Title}", name);
        }
    }
}
