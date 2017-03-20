using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 生成栏目静态化文件所需Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class GenerateColumnOutput
    {

    }
}
