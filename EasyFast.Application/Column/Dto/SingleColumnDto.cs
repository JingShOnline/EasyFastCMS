using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto
{
    [AutoMap(typeof(Core.Entities.Column.Column))]
    public class SingleColumnDto : ColumnDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public SingleColumnDto() : base()
        {
            ColumnTypeEnum = Core.Entities.ColumnTypeEnum.Single;
           
        }

        /// <summary>
        /// 单页节点模板
        /// </summary>
        [StringLength(100)]
        public string SingleTemplate { get; set; }

        /// <summary>
        /// 单页节点生成规则
        /// </summary>
        public string SingleHtmlRule { get; set; }

    }
}
