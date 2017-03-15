using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace EasyFast.Application.Model.Dto
{
    /// <summary>
    /// 基本信息的Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Model))]
    public class BasicModelOutput : EntityDto
    {
        /// <summary>
        /// 模型名称
        /// </summary>
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
        public string IsCountHits { get; set; }

        /// <summary>
        /// 关联表名
        /// </summary>
        public string TableName { get; set; }

    }
}
