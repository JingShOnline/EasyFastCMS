using System;
using System.Collections.Generic;
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
        Normal = 1,

        /// <summary>
        /// 单页栏目，无法添加内容的栏目，如首页
        /// </summary>
        Single = 2
    }
}
