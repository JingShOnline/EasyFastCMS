using Abp.Application.Services.Dto;
using EasyFast.Core;
using EasyFastCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Dto
{
    /// <summary>
    /// 分页并且含有搜索的Dto
    /// </summary>
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 返回条数
        /// </summary>
        [Range(1, EasyFastConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        /// <summary>
        /// 过滤条数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 默认为返回条数为1
        /// </summary>
        public PagedAndFilteredInputDto()
        {
            MaxResultCount = EasyFastConsts.DefaultPageSize;
        }
    }
}
