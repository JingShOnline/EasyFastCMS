using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 栏目名称Dto
    /// </summary>
    [AutoMap(typeof(Core.Entities.Column))]
    public class ColumnNameOutput : EntityDto
    {
        public string Name { get; set; }

        public List<ColumnNameOutput> Children { get; set; }
    }
}
