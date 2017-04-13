
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Text;
using System.Web;

namespace EasyFast.Common
{
    /// <summary>
    /// RazorEngine帮助类
    /// </summary>
    public class RazorHelper
    {
        /// <summary>
        /// cshtml文件解析并返回字符串
        /// </summary>

        /// <param name="html">cshtml内容</param>
        /// <param name="csName">缓存名</param>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static string Parsecshtml(string html, string csName, object model = null)
        {
            string cshtml = Engine.Razor.RunCompile(html, csName, null, model);
            return cshtml;
        }
        public static RawString UrlEnCode(string str)
        {
            return new RawString(HttpContext.Current.Server.UrlEncode(str));
        }


        public static string GetExtendedAttribute(object extendedAttribute)
        {
            StringBuilder sb = new StringBuilder();

            //拿到程序集
            Type exendType = extendedAttribute.GetType();
            //拿到所有的公共属性
            PropertyInfo[] exendInfos = exendType.GetProperties();

            foreach (PropertyInfo exendInfo in exendInfos)
            {
                //拿到属性
                string attribute = exendInfo.Name;
                //拿到值
                object attValue = exendInfo.GetValue(extendedAttribute);

                sb.Append(" " + attribute).Append("='").Append(attValue).Append("' ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// DropDownList
        /// </summary>
        /// <param name="items">数据</param>
        /// <param name="optValue">显示的值</param>
        /// <param name="optText">实际的值</param>
        /// <param name="selectedValue">被选中的项</param>
        /// <param name="extendedAttribute">扩展属性</param>
        /// <returns></returns>
        public static RawString DropDownList(IEnumerable items, string optValue, string optText, object selectedValue, object extendedAttribute)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<select ");

            sb.Append(GetExtendedAttribute(extendedAttribute));

            sb.Append(">");

            foreach (var item in items)
            {
                //拿到程序集
                Type itemType = item.GetType();
                //拿到optValue的属性
                PropertyInfo valuePropert = itemType.GetProperty(optValue);
                //拿到valuePropert属性的值
                object itemvalue = valuePropert.GetValue(item);

                //拿到optText的属性
                PropertyInfo textPropert = itemType.GetProperty(optText);
                //拿到valuePropert属性的值
                object itemText = textPropert.GetValue(item);

                sb.Append("<option value='").Append(itemvalue).Append("' ");
                if (object.Equals(selectedValue, itemvalue))
                {
                    sb.Append("selected");
                }
                sb.Append(">").Append(itemText).Append("</option>");

            }
            sb.Append("</select>");

            return new RawString(sb.ToString());
        }



        /// <summary>
        /// 单选框
        /// </summary>
        /// <param name="items">数据</param>
        /// <param name="id">id 单选框的id</param>
        /// <param name="name">name 单选框的name</param>
        /// <param name="selectedValue">selectedValue 被选中的项</param>
        /// <returns></returns>
        public static RawString RadioButtonList(IEnumerable items, string id, string name, object selectedValue)
        {
            StringBuilder sb = new StringBuilder();


            foreach (var item in items)
            {

                //拿到程序集
                Type itemType = item.GetType();

                //拿到id的属性描述
                PropertyInfo idPropert = itemType.GetProperty(id);
                //拿到idPropery属性的值
                object idPropertValue = idPropert.GetValue(item);
                sb.Append("<input type='radio' value='");
                sb.Append(idPropertValue).Append("' name='").Append(name).Append("'");
                //判断
                if (object.Equals(idPropertValue, selectedValue))
                {
                    sb.Append("checked");
                }
                sb.Append("/>");

                //拿到name属性的描述
                PropertyInfo namePropery = itemType.GetProperty("name");
                //拿到namePropery的值
                object namePeoperyValue = namePropery.GetValue(item);

                sb.Append("<label>").Append(namePeoperyValue).Append("</label>");
            }

            return new RawString(sb.ToString());
        }

        /// <summary>
        /// 比对是否选中
        /// </summary>
        public static bool Contains(IEnumerable items, object value)
        {
            foreach (object item in items)
            {
                if (object.Equals(item, value))
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="items">数据</param>
        /// <param name="value">实际值</param>
        /// <param name="text">显示的值</param>
        /// <param name="selectedValue">被选的中项的集合</param>
        /// <param name="name">复选框的name</param>
        /// <returns></returns>
        public static RawString CheckButtonList(IEnumerable items, string value, string text, IEnumerable selectedValue, string name)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in items)
            {
                //拿到程序集
                Type itemType = item.GetType();

                //拿到id属性的描述
                PropertyInfo idPropert = itemType.GetProperty(value);
                //拿到idPropert的值
                object idPropertValue = idPropert.GetValue(item);
                //拿到name属性的描述
                PropertyInfo namePropert = itemType.GetProperty(text);
                //拿到namePropert的值
                object namePropertValue = namePropert.GetValue(item);


                sb.Append("<input type='checkBox' id='").Append(name).Append(i).Append("' value='").Append(idPropertValue).Append("' name='").Append(name).Append("'");
                if (Contains(selectedValue, idPropertValue))
                {
                    sb.Append(" checked");
                }
                sb.Append("/>");

                sb.Append("<label for='").Append(name).Append(i).Append("'>").Append(namePropertValue).Append("</label>");
                i++;

            }

            return new RawString(sb.ToString());
        }

        /// <summary>
        /// 把给定路径的文件读取并原样返回
        /// </summary>
        /// <param name="filepath">路径</param>
        /// <returns></returns>
        public static RawString Include(string filepath)
        {
            //拿到当前的Httpcontent对象
            HttpContext context = HttpContext.Current;

            string html = File.ReadAllText(context.Server.MapPath(filepath));

            return new RawString(html);
        }

        /// <summary>
        /// 把给定的字符串原样输出
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static RawString Raw(string text)
        {
            return new RawString(text);
        }


        /// <summary>
        /// 分页组件,生成页码的html
        /// </summary>
        /// <param name="urlFormat">约定的超链接格式,比如 Index_{page}.cshtml,动态的替换{pageNum}为当前页码</param>
        /// <param name="totalSize">数据的总条数</param>
        /// <param name="pageSize">每一页显示的条数</param>
        /// <param name="currentPage">当前的页码</param>
        /// <returns>页码的html</returns>
        public static RawString Pager(string urlFormat, long totalSize, long pageSize, long currentPage)
        {

            //拼接html代码
            StringBuilder sb = new StringBuilder();

            //总页数 (总条数/每一页面显示的条数)天花板数
            long totalpageCount = (long)Math.Ceiling((totalSize * 1.0f) / (pageSize * 1.0f));

            //当前页码前最多显示五页、后面最多显示五页==11页
            //计算页码条中的第一条页码
            long firstPageNum = Math.Max(currentPage - 5, 1);
            //计算页码和可的最后一条页码
            long lastPageNum = Math.Min(currentPage + 5, totalpageCount);

            //生成首页
            //sb.Append("<li><a href='" + urlFormat.Replace("{Page}", "1") + "'>首页</a></li>");
            //从相对于当前页码的第一条页码开始到相对于当前页码的最后一条页码结束
            for (long i = firstPageNum; i <= lastPageNum; i++)
            {
                //生成当前页
                if (i == (currentPage + 1))
                {
                    sb.Append("<li class='active'><a>" + i + "</a></li>");
                }
                else
                {
                    sb.Append("<li><a href='" + urlFormat.Replace("{Page}", i.ToString()) + "'>" + i + "</a></li>");
                }

            }

            ////生成尾页
            //sb.Append("<li><a href='" + urlFormat.Replace("{Page}", totalpageCount.ToString()) + "'>尾页</a></li>");

            return new RawString(sb.ToString());
        }
    }
}
