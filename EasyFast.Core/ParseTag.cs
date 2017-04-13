using System.Collections.Generic;

namespace EasyFast.Core
{
    public class ParseTag
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 参数  Key- value={(where or...) value}
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// 排序 Ordre by {xorting} desc/asc
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        /// 标签类型
        /// </summary>
        public string TagType { get; set; }
    }

}
