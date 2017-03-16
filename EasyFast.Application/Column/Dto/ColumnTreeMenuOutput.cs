using Abp.AutoMapper;
using EasyFast.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    public class ColumnTreeMenuOutput : EasyUITree<ColumnTreeMenuOutput>
    {

        /// <summary>
        /// 模型Id
        /// </summary>
        public string ModelId { get; set; }

        /// <summary>
        /// model表中的控制器
        /// </summary>
        public string ModelManagerControlerPath { get; set; }

        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelModelName { get; set; }


        /// <summary>
        /// 自定义属性
        /// </summary>
        public object Attributes { get; set; }
    }
}
