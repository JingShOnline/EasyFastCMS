using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities.Column
{
    /// <summary>
    /// 栏目领域服务
    /// </summary>
    public class ColumnManager : DomainService, IColumnManager
    {
        /// <summary>
        /// 初始化栏目 设置栏目首页、列表页、生成地址,解析内容页生成地址
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public void InitColumn(Column column)
        {
            column.IndexHtmlRule = $"{column.Name}/index.html";
            column.ListHtmlRule = $"{column.Name}/List/list_{{id}}.html";

            var now = DateTime.Now;

            //先完成功能,后期可设计成解析器模式
            column.ContentHtmlRule = column.ContentHtmlRule.Replace("{ColumnDir}", column.Name).Replace("{Year}", now.Year.ToString()).Replace("{Month}", now.Month.ToString()).Replace("{Day}", now.Day.ToString()) + ".html";
        }


        /// <summary>
        /// 初始化单页 设置单页生成文件路径
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public void InitSignleColumn(Column column)
        {
            if (string.IsNullOrWhiteSpace(column.SingleHtmlRule))
            {
                //默认
                column.SingleHtmlRule = $"{{SignleStaticPage}}/{column.Name}.html";
            }
            else
            {
                column.SingleHtmlRule = $"{{SignleStaticPage}}/{column.SingleHtmlRule}.html";
            }
        }
    }
}
