using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using EasyFast.Application.Dto;

namespace EasyFast.Application.ContentModel.ModelRecord.Dto
{
    /// <summary>
    /// 获取模型输入Dto
    /// </summary>
    public class GetModelsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }


        public void Normalize()
        {
            Sorting = "CreationTime";
        }
    }
}
