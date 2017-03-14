using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Common.Extend.Object.Attribute
{
    /// <summary>
    /// 特性帮助类 / 扩展Object
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// 拿到特性中存储的值 
        /// </summary>
        /// <typeparam name="T">特性</typeparam>
        /// <param name="o"></param>
        /// <param name="fieldName">字段或属性名</param>
        /// <returns></returns>
        public static object GetAttributeValue<T>(this object o, string fieldName) where T : class
        {
            var type = o.GetType();

            var attributes = type.GetField(o.ToString()).GetCustomAttributes(typeof(T), false);
           
            var attribute = attributes[0] as T;

            return attribute.GetType().GetProperty(fieldName).GetValue(attribute);

        }
    }
}
