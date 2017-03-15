using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Content.Dto
{
    /// <summary>
    /// 用于基本信息展示的Output
    /// </summary>
    public class GridContentOutput : EntityDto
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        public int ColumnId { get; set; }

        /// <summary>
        /// 所属栏目
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 模型Id
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelModelName { get; set; }       
     
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 总点击量
        /// </summary>
        public int Hits { get; set; }


    }
}
