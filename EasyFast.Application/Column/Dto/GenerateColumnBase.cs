using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 静态化栏目Dto
    /// </summary>
    public class GenerateColumnBase : EntityDto
    {
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 栏目目录
        /// </summary>
        public string Dir { get; set; }

    }
}
