using EasyFast.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Content.Dto
{
    public class PagedGridContentInput : PagedSortedAndFilteredInputDto
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        public int? ColumnId { get; set; }
    }
}
