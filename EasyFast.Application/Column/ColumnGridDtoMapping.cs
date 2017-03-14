using EasyFastCMS.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyFast.Application.Column.Dto;
using EasyFast.Common.Extend.Object.Attribute;
using System.ComponentModel;

namespace EasyFast.Application.Column
{
    public class ColumnGridDtoMapping : IDtoMapping
    {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<Core.Entities.Column, ColumnGridOutput>().ForMember("ColumnType", o => o.MapFrom(c => c.ColumnTypeEnum.GetAttributeValue<DescriptionAttribute>("Description")));
        }
    }
}
