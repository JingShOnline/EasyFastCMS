using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyFast.Application.Model.Dto;
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
            mapperConfig.CreateMap<Core.Entities.Model, BasicModelOutput>().ForMember("IsCountHits", o => o.MapFrom(c => c.IsCountHits ? "是" : "否"));
        }
    }
}
