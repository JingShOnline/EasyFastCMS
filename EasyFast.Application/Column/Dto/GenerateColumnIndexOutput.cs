using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 生成静态化文件所用的栏目Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class GenerateColumnIndexOutput : EntityDto
    {
        /// <summary>
        /// 栏目类型
        /// </summary>
        public ColumnTypeEnum ColumnTypeEnum { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 栏目首页模板
        /// </summary>
        public string IndexTemplate { get; set; }

        /// <summary>
        /// 首页生成规则
        /// </summary>
        public string IndexHtmlRule { get; set; }

        /// <summary>
        /// 单页节点生成规则
        /// </summary>
        public string SingleHtmlRule { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Dir { get; set; }


    }
}
