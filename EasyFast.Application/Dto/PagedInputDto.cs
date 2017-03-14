using Abp.Application.Services.Dto;
using EasyFast.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Dto
{
    /// <summary>
    /// 分页InputDto
    /// </summary>
    public class PagedInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 返回条数
        /// </summary>
        [Range(1, EasyFastConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        /// <summary>
        /// 跳过的条数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        /// <summary>
        /// 默认返回条数为10
        /// </summary>
        public PagedInputDto()
        {
            MaxResultCount = EasyFastConsts.DefaultPageSize;
        }
    }
}
