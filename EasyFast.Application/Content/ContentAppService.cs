using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using EasyFast.Application.Content.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using Abp.Collections.Extensions;
using System.Linq.Dynamic;
using System.Data.Entity;
using Abp.Linq.Extensions;
using Abp.AutoMapper;

namespace EasyFast.Application.Content
{
    /// <summary>
    /// 内容资源
    /// </summary>
    public class ContentAppService : ApplicationService, IContentAppService
    {

        private readonly IRepository<Common_Model> _commonModelRepository;

        public ContentAppService(IRepository<Common_Model> modelRepository)
        {
            _commonModelRepository = modelRepository;
        }

        /// <summary>
        /// 分页并搜索获取内容信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GridContentOutput>> GetGridContents(PagedGridContentInput input)
        {
            input.Sorting = input.Sorting ?? "LastModificationTime";
            var query = _commonModelRepository.GetAll()
                .WhereIf(input.ColumnId.HasValue, o => o.ColumnId == input.ColumnId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), o => o.Title.Contains(input.Filter) || o.Info.Contains(input.Filter) || o.Guide.Contains(input.Filter));
            var count = await query.CountAsync();
            var list = query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            return new PagedResultDto<GridContentOutput>(count, list.MapTo<List<GridContentOutput>>());
        }
    }
}
