using EasyFast.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Content.Dto
{
    public class DataGridInput : EasyUIDataGridPager
    {
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 栏目Id
        /// </summary>
        public int? ColumnId { get; set; }
    }
}
