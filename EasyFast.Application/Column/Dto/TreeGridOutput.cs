using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using EasyFast.Core.Entities;

namespace EasyFast.Application.Column.Dto
{
    [AutoMapFrom(typeof(Core.Entities.Column.Column))]
    public class TreeGridOutput: EntityDto
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public ColumnTypeEnum ColumnTypeEnum { get; set; }
        public string ContentCount { get; set; }
        public int OrderId { get; set; }
        public List<TreeGridOutput> Children { get; set; }
    }
}
