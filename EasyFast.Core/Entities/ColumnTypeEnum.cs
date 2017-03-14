using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities
{
    public enum ColumnTypeEnum
    {
        /// <summary>
        /// 普通栏目
        /// </summary>
        [Description("栏目")]
        Normal = 1,

        /// <summary>
        /// 单页栏目，无法添加内容的栏目，如首页
        /// </summary>
        [Description("单页栏目")]
        Single = 2
    }
}
