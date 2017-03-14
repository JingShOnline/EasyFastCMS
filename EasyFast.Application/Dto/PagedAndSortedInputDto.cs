using Abp.Application.Services.Dto;
using EasyFast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Dto
{
    /// <summary>
    /// 分页并且具有排序InputDto
    /// </summary>
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        /// <summary>
        /// 排序条件
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        /// 默认返回条数为10
        /// </summary>
        public PagedAndSortedInputDto()
        {
            MaxResultCount = EasyFastConsts.DefaultPageSize;
        }
    }
}
