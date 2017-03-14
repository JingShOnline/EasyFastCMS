using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyFast.Application.ContentModel.ModelRecord.Dto;
using EasyFastCMS.Application.AutoMapper;

namespace EasyFast.Application.ContentModel.ModelRecord
{
    /// <summary>
    /// 内容模型记录表map映射配置
    /// </summary>
    public class ModelRecordDtoMapping : IDtoMapping
    {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<Core.Entities.ModelRecord, BasicModelRecordOutput>().ForMember("IsCountHits", o => o.MapFrom(c => c.IsCountHits ? "是" : "否"));
        }
    }
}
