using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Dto
{
    /// <summary>
    /// 分页 排序 过滤 InputDto
    /// </summary>
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        /// <summary>
        /// 过滤字段
        /// </summary>
        public string Filter { get; set; }
    }
}
