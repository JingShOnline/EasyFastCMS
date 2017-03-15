using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace EasyFast.Application.Model.Dto
{
    /// <summary>
    /// 内容模型记录Dto
    /// </summary>
    [AutoMap(typeof(Core.Entities.Model))]
    public class ModelDto : EntityDto
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        [Required(ErrorMessage = "请输入模型名称")]
        public string ModelName { get; set; }

        /// <summary>
        /// 模型描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 是否记录点击次数
        /// </summary>
        public bool IsCountHits { get; set; }

        /// <summary>
        /// 关联表名
        /// </summary>
        [Required(ErrorMessage = "请输入关于表名")]
        public string TableName { get; set; }

        /// <summary>
        /// 管理控制器路径
        /// </summary>
        public string ManagerControlerPath { get; set; }

        /// <summary>
        /// 内容页模板
        /// </summary>
        public string ContentTemplatePath { get; set; }

        /// <summary>
        /// 搜索界面模板
        /// </summary>
        public string SearchPageTamplatePath { get; set; }

        /// <summary>
        /// 搜索结果页面模板
        /// </summary>
        public string SearchResultTemplatePath { get; set; }
    }
}
